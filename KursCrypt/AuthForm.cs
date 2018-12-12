using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImapX.Authentication;
using ImapX;

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
                    string host_str = tb_mail.Text.Substring(tb_mail.Text.IndexOf('@') + 1);
                    client = new ImapClient("imap." + host_str, Main.rcv_port, true, false);
                    if (client.Connect())
                    {
                        if (client.Login(tb_mail.Text, tb_pass.Text))
                        {
                            Email profile = new Email(tb_mail.Text, tb_pass.Text, tb_name.ForeColor == SystemColors.InactiveCaption?"":tb_name.Text);
                            emails.Add(profile);
                            Boxes.AddToBoxlist(profile);
                        }
                        else
                        {
                            MessageBox.Show("Неверно введённый E-mail или пароль", null, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка соединения", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
