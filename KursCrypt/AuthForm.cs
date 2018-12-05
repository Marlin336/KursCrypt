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
                    client = new ImapClient(Main.curr_client.Host, Main.curr_client.Port, true, false);
                    if (client.Connect())
                    {
                        if (client.Login(tb_mail.Text, tb_pass.Text))
                        {
                            Email profile = new Email(tb_mail.Text, tb_pass.Text);
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
                catch (Exception)
                { 
                    throw;
                }
                finally
                {
                    tb_mail.Text = tb_pass.Text = null;
                }
            }
        }
    }
}
