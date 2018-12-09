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
using System.Net.Mail;

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
    public enum Folder { inbox, sent, junk, trash};
    public partial class MainForm : Form
    {
        public bool state;
        public List<Email> emails = new List<Email>();
        public int curr_email = -1;
        public ImapClient curr_client = new ImapClient("imap.mail.ru", 993, true, false);
        public Folder curr_fold { get; private set; } = Folder.inbox;

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
            if (curr_email != -1)
            {
                WriteForm write = new WriteForm(this);
                write.Show();
            }
            else
                MessageBox.Show("Для того чтобы написать письмо нужно авторизоваться", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void stateIndicator_Click(object sender, EventArgs e)
        {
            if (state)
            {
                curr_client.Disconnect();
                state = false;
                stateIndicator.Text = curr_email!=-1? emails[emails.FindIndex(em => em.id == curr_email)].Login : "Offline"; //Эту магию нужно понять! Очень полезно
                stateIndicator.ForeColor = Color.Red;
            }
            else
            {
                if (curr_client.Connect())
                {
                    state = true;
                    stateIndicator.Text = curr_email != -1 ? emails[emails.FindIndex(em => em.id == curr_email)].Login : "Online";
                    stateIndicator.ForeColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Не удается подключиться. Проверьте подключение к сети!", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            отправленныеToolStripMenuItem.Checked = спамToolStripMenuItem.Checked = корзинаToolStripMenuItem.Checked = false;
            входящиеToolStripMenuItem.Checked = true;
            curr_fold = Folder.inbox;
            RedrawMailList();
        }

        private void отправленныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            входящиеToolStripMenuItem.Checked = спамToolStripMenuItem.Checked = корзинаToolStripMenuItem.Checked = false;
            отправленныеToolStripMenuItem.Checked = true;
            curr_fold = Folder.sent;
            RedrawMailList();
        }

        private void спамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            входящиеToolStripMenuItem.Checked = отправленныеToolStripMenuItem.Checked = корзинаToolStripMenuItem.Checked = false;
            спамToolStripMenuItem.Checked = true;
            curr_fold = Folder.junk;
            RedrawMailList();
        }

        private void корзинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            входящиеToolStripMenuItem.Checked = спамToolStripMenuItem.Checked = отправленныеToolStripMenuItem.Checked = false;
            корзинаToolStripMenuItem.Checked = true;
            curr_fold = Folder.trash;
            RedrawMailList();
        }

        public void RedrawMailList()
        {
            //Нужно получить сообщения из сервера
            List<ImapX.Message> messages = new List<ImapX.Message>();
            //= imap.Folders[comboBox3.SelectedIndex].Search("ALL", ImapX.Enums.MessageFetchMode.ClientDefault, uo.count);
            lb_mail.Items.Clear();
            switch (curr_fold)
            {
                case Folder.inbox:
                    foreach (var item in curr_client.Folders.Inbox.Messages)
                    {
                        lb_mail.Items.Add("От: " + item.From + "\n" + "Тема: " + item.Subject + "\n" + item.Date);
                    }
                    break;
                case Folder.sent:
                    foreach (var item in curr_client.Folders.Sent.Messages)
                    {
                        lb_mail.Items.Add("От: " + item.From + "\n" + "Тема: " + item.Subject + "\n" + item.Date);
                    }
                    break;
                case Folder.junk:
                    foreach (var item in curr_client.Folders.Junk.Messages)
                    {
                        lb_mail.Items.Add("От: " + item.From + "\n" + "Тема: " + item.Subject + "\n" + item.Date);
                    }
                    break;
                case Folder.trash:
                    foreach (var item in curr_client.Folders.Trash.Messages)
                    {
                        lb_mail.Items.Add("От: " + item.From + "\n" + "Тема: " + item.Subject + "\n" + item.Date);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
