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
    struct Email
    {
        int id;// Выдается на сессию
        string Login, Address, Password;
    }
    public partial class MainForm : Form
    {
        private List<Email> emails = new List<Email>();
        private int curr_email = -1;
        public ImapX.ImapClient client = new ImapX.ImapClient();

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
