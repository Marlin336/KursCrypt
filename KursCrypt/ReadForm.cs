using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.Mail;
using MimeKit;

namespace KursCrypt
{
    public partial class ReadForm : Form
    {
        MainForm Main;
        string id;
        Email email_ref;
        public MimeMessage message { get; private set; }

        public ReadForm(MainForm main, Folder folder, string id)
        {
            InitializeComponent();
            Main = main;
            email_ref = main.emails.Find(em => em.id == main.curr_id);
            this.id = id;
            try
            {
                switch (folder)
                {
                    case Folder.inbox:
                        Main.curr_client.Inbox.Open(MailKit.FolderAccess.ReadOnly);
                        message = Main.curr_client.Inbox.First(msg => msg.MessageId == id);
                        break;
                    case Folder.sent:
                        Main.curr_client.GetFolder(MailKit.SpecialFolder.Sent).Open(MailKit.FolderAccess.ReadOnly);
                        message = Main.curr_client.GetFolder(MailKit.SpecialFolder.Sent).First(msg => msg.MessageId == id);
                        break;
                    case Folder.junk:
                        Main.curr_client.GetFolder(MailKit.SpecialFolder.Junk).Open(MailKit.FolderAccess.ReadOnly);
                        message = Main.curr_client.GetFolder(MailKit.SpecialFolder.Junk).First(msg => msg.MessageId == id);
                        break;
                    case Folder.trash:
                        Main.curr_client.GetFolder(MailKit.SpecialFolder.Trash).Open(MailKit.FolderAccess.ReadOnly);
                        message = Main.curr_client.GetFolder(MailKit.SpecialFolder.Trash).First(msg => msg.MessageId == id);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                message = MimeMessage.Load("Saved/" + email_ref.Address + "/" + folder.ToString() + "/" + id);
            }
            tb_opentext.Text = message.TextBody;
            tb_subject.Text = message.Subject;
            tb_from.Text = message.From.Mailboxes.First().Address;
            b_attach.Enabled = message.Attachments.Count() > 0;
            MimeKit.HeaderList headers = new MimeKit.HeaderList();
            if (message.Headers.Contains("keyswap"))
            {
                if (message.Headers["keyswap"] == "0")//Пришёл запрос
                {
                    if (MessageBox.Show("Произвести обмен ключами шифрования?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Main.KeyHolders.AddReciever(email_ref.Address, message.From.Mailboxes.First().Address);
                        Main.KeyHolders.SetKey(email_ref.Address, message.From.Mailboxes.First().Address, message.Headers["keypub"], false);
                        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                        {
                            MailMessage replyMail = new MailMessage(new MailAddress(email_ref.Address, email_ref.Name), new MailAddress(message.From.Mailboxes.First().Address))
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
                            Main.KeyHolders.AddReciever(email_ref.Address, message.From.Mailboxes.First().Address);
                            Main.KeyHolders.SetKey(email_ref.Address, message.From.Mailboxes.First().Address, rsa.ToXmlString(true), true);
                            Main.SerializeKeyFile();
                        }
                    }
                }
                else //Пришёл ответ
                {
                    Main.KeyHolders.SetKey(email_ref.Address, message.From.Mailboxes.First().Address, message.Headers["keypub"], false);
                    Main.SerializeKeyFile();
                    MessageBox.Show("Запрос подверждён. Теперь можно шифровать письма с данным пользователем", "Запрс подтверждён", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
            else
            {
                if (message.Headers.Contains("crypt")) //Есть флаги-признаки шифрования => отправлено с этого клиента
                {
                    byte cryptF = byte.Parse(message.Headers["crypt"]);
                    string str = (cryptF & 2) != 0 ? message.TextBody.Substring(0, message.TextBody.IndexOf("\r")) : message.TextBody;
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
                            rsa.FromXmlString(Main.KeyHolders.GetKey(email_ref.Address, message.From.Mailboxes.First().Address, true));
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
            WriteForm write = new WriteForm(Main, addressee, "Re:" + tb_subject.Text);
            write.ShowDialog();
        }
    }
}
