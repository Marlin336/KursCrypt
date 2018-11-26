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
        public ImapX.ImapClient curr_client = new ImapX.ImapClient("imap.mail.ru", 993, true, true);

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
            if (curr_email != -1)
            {
                WriteForm write = new WriteForm(this);
                write.Show();
            }
            else
                MessageBox.Show("Для того чтобы написать письмо нужно авторизоваться", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
