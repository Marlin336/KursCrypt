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
        public int id;// Выдается на сессию
        public string Login, Password;
    }
    public partial class MainForm : Form
    {
        public List<Email> emails = new List<Email>();
        private int curr_email = -1;
        public ImapClient curr_client = new ImapClient("imap.mail.ru", 993, true, true);

        public MainForm()
        {
            InitializeComponent();
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
    }
}
