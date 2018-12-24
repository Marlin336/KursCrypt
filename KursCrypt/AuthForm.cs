using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KursCrypt
{
    public partial class AuthForm : Form
    {
        BoxesForm Boxes;
        MainForm Main;
        List<Email> emails;
        ImapClient client;

        public AuthForm(BoxesForm boxes)
        {
            Boxes = boxes;
            Main = boxes.Main;
            emails = Main.emails;
            InitializeComponent();
        }
        private void bAccept_Click(object sender, EventArgs e)
        {
            Regex rgx = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (!rgx.IsMatch(tb_mail.Text))
            {
                MessageBox.Show("Неверно введённый E-mail", null, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                try
                {
                    Main.host = tb_mail.Text.Substring(tb_mail.Text.IndexOf('@') + 1);
                    client = new ImapClient();
                    client.Connect("imap." + Main.host, Main.rcv_port, true);
                    if (client.IsConnected)
                    {
                        client.Authenticate(tb_mail.Text, tb_pass.Text);
                        if(client.IsAuthenticated)
                        {
                            if (Main.emails.Exists(em => em.Address == tb_mail.Text))
                            {
                                MessageBox.Show("Ящик с таким адресом уже связан с клиентом", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                            Email profile = new Email(tb_mail.Text, tb_pass.Text, tb_name.ForeColor == SystemColors.InactiveCaption?tb_mail.Text.Substring(0,tb_mail.Text.IndexOf('@')):tb_name.Text);
                            emails.Add(profile);
                            Boxes.AddToBoxlist(profile);
                            XDocument document = XDocument.Load("Profile.xml");
                            document.Root.Add(
                                 new XElement("user",
                                    new XElement("ads", profile.Address),
                                    new XElement("pwd", profile.Password),
                                    new XElement("nm", profile.Name)
                                    )
                                );
                            document.Save("Profile.xml");
                            Main.KeyHolders.AddUser(tb_mail.Text);
                            Main.SerializeKeyFile();
                        }
                        else
                        {
                            MessageBox.Show("Неверно введённый E-mail или пароль", null, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        throw new Exception("Не удалось подключиться к серверу. Проверьте соединение с сетью!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }
        private void tb_name_Enter(object sender, EventArgs e)
        {
            if (tb_name.ForeColor == SystemColors.InactiveCaption)
            {
                tb_name.Text = null;
                tb_name.ForeColor = SystemColors.WindowText;
            }
        }
        private void tb_name_Leave(object sender, EventArgs e)
        {
            if (tb_name.Text.Length == 0)
            {
                tb_name.ForeColor = SystemColors.InactiveCaption;
                tb_name.Text = "Необязательно";
            }
        }
    }
}
