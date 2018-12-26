using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KursCrypt
{
    public partial class ReadForm : Form
    {
        MainForm Main;
        long uid;
        Email email_ref;
        public ImapX.Message message { get; private set; }

        public ReadForm(MainForm main, ImapX.Folder folder, long uid)
        {
            InitializeComponent();
            Main = main;
            email_ref = main.emails.Find(em => em.id == main.curr_id);
            this.uid = uid;
            message = folder.Messages.First(msg => msg.UId == uid);
            tb_opentext.Text = message.Body.Text;
            tb_subject.Text = message.Subject;
            tb_from.Text = message.From.DisplayName + " <" + message.From.Address + ">";
            b_attach.Enabled = message.Attachments.Length > 0;

            string reqestflag;
            if (message.Headers.TryGetValue("keyswap", out reqestflag))
            {
                if (reqestflag == "0")//Пришёл запрос
                {
                    if (MessageBox.Show("Произвести обмен ключами шифрования?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Main.KeyHolders.AddReciever(email_ref.Address, message.From.Address);
                        Main.KeyHolders.SetKey(email_ref.Address, message.From.Address, message.Headers["keypub"], false);
                        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                        {
                            MailMessage replyMail = new MailMessage(new MailAddress(email_ref.Address, email_ref.Name), new MailAddress(message.From.Address))
                            {
                                Subject = "ОТВЕТ НА ЗАПРОС ОБМЕНА КЛЮЧАМИ"
                            };
                            replyMail.Headers.Add("keyswap", "1");
                            replyMail.Headers.Add("keypub", rsa.ToXmlString(false));
                            SmtpClient smtp = new SmtpClient
                            {
                                Port = Main.snd_port,
                                Host = "smtp." + Main.host,
                                EnableSsl = true,
                                Timeout = 10000,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new System.Net.NetworkCredential(email_ref.Address, email_ref.Password)
                            };
                            try
                            {
                                smtp.Send(replyMail);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Не удалось отправить запрос\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                throw;
                            }
                            Main.KeyHolders.AddReciever(email_ref.Address, message.From.Address);
                            Main.KeyHolders.SetKey(email_ref.Address, message.From.Address, rsa.ToXmlString(true), true);
                            Main.SerializeKeyFile();
                        }
                    }
                }
                else //Пришёл ответ
                {
                    Main.KeyHolders.SetKey(email_ref.Address, message.From.Address, message.Headers["keypub"], false);
                    Main.SerializeKeyFile();
                    MessageBox.Show("Запрос подверждён. Теперь можно шифровать письма с данным пользователем", "Запрс подтверждён", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
            else
            {
                string cryptflags;
                if (message.Headers.TryGetValue("crypt", out cryptflags)) //Есть флаги-признаки шифрования => отправлено с этого клиента
                {
                    byte cryptF = byte.Parse(cryptflags);
                    string str = (cryptF & 2) != 0 ? message.Body.Text.Substring(0, message.Body.Text.IndexOf("\r")) + "=" : message.Body.Text;
                    if ((cryptF & 1) != 0)//Флаг подписи
                    {
                        byte[] sign = Convert.FromBase64String(message.Headers["dsasign"]);
                        string dsaKey = message.Headers["dsakey"];
                        if (Encryption.VerifySign(Encoding.Default.GetBytes(str), dsaKey, sign))
                        {
                            MessageBox.Show("Цифровая подпись прошла верификацию", "DSAGuardian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Цифровая подпись не прошла верификацию. Данные могли быть повреждены", "DSAGuardian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if ((cryptF & 2) != 0)//Флаг шифрования
                    {
                        byte[] buff = Convert.FromBase64String(message.Headers["deskey"]);
                        byte[] Key;
                        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                        {
                            rsa.FromXmlString(Main.KeyHolders.GetKey(email_ref.Address, message.From.Address, true));
                            Key = Encryption.DecRSA(buff, rsa.ExportParameters(true), true);
                        }
                        byte[] IV = Convert.FromBase64String(message.Headers["desiv"]);
                        tb_opentext.Text = Encryption.DecDES(Convert.FromBase64String(str), Key, IV);
                    }
                }
            }
        }
        private void b_attach_Click(object sender, EventArgs e)
        {
            InAttachForm attachForm = new InAttachForm(message);
            attachForm.Show();
        }
        private void b_reply_Click(object sender, EventArgs e)
        {
            string addressee = tb_from.Text.Substring(tb_from.Text.IndexOf('<') + 1);
            addressee = addressee.Substring(0, addressee.Length - 1);
            WriteForm write = new WriteForm(Main, addressee, "Re:" + tb_subject.Text);
            write.ShowDialog();
        }
    }
}
