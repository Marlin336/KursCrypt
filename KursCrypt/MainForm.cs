using ImapX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursCrypt
{
    public struct Email
    {
        private static int count = 0;
        public int id;// Выдается на сессию
        public string Login, Password;
        public Email(string login, string password)
        {
            id = count++;
            Login = login;
            Password = password;
        }
    }
    public partial class MainForm : Form
    {
        public bool state;
        public List<Email> emails = new List<Email>();
        private int curr_email = -1;
        public ImapClient curr_client = new ImapClient("imap.mail.ru", 993, true, true);

        public MainForm()
        {
            InitializeComponent();
            state = curr_client.Connect();
            if (state)
            {
                stateIndicator.Text = "Online";
                stateIndicator.ForeColor = Color.LightGreen;
            }
            else
            {
                stateIndicator.Text = "Offline";
                stateIndicator.ForeColor = Color.Red;
            }
        }

        private void почтовыеЯщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxesForm boxes = new BoxesForm(this);
            boxes.ShowDialog();
        }

        private void написатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Write_message(null, null);
        }

        private void b_reply_Click(object sender, EventArgs e)
        {
            Write_message(tb_from.Text, "Re: " + tb_subject.Text);
        }

        private void Write_message(string to, string subj)
        {
            WriteForm write = new WriteForm(this, to, subj);
            write.Show();
            /// ПОКА ТЕСТ

            //if (curr_email != -1)
            //{
            //    WriteForm write = new WriteForm(this);
            //    write.Show();
            //}
            //else
            //    MessageBox.Show("Для того чтобы написать письмо нужно авторизоваться", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void stateIndicator_Click(object sender, EventArgs e)
        {
            if (state)
            {
                curr_client.Disconnect();
                state = false;
                stateIndicator.Text = "Offline";
                stateIndicator.ForeColor = Color.Red;
            }
            else
            {
                if (curr_client.Connect())
                {
                    state = true;
                    stateIndicator.Text = "Online";
                    stateIndicator.ForeColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Не удается подключиться. Проверьте подключение к сети!", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
