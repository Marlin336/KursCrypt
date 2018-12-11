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
using System.IO;
using System.Xml.Linq;

namespace KursCrypt
{
    public struct Email
    {
        private static int count = 0;
        public int id;// Выдается на сессию
        public string Address, Password, Name;
        public Email(string login, string password, string name)
        {
            id = count++;
            Address = login;
            Password = password;
            Name = name;
        }
    }
    public enum Folder { inbox, sent, junk, trash};
    public partial class MainForm : Form
    {
        public int rcv_port { get; private set; }
        public int snd_port { get; private set; }
        public string host { get; private set; }
        public bool state;
        public List<Email> emails = new List<Email>();
        public int curr_id { get; set; } = -1;
        public ImapClient curr_client = null;
        public Folder curr_fold { get; private set; } = Folder.inbox;

        public MainForm()
        {
            InitializeComponent();
            if(!File.Exists("Settings.xml"))
            { 
                MessageBox.Show("Файл настроек не найден. Будет создан новый файл с настройками по умолчанию", "Файл настроек не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XElement setfile =  new XElement(
                        "connect",
                        new XElement("host", "mail.ru"),
                        new XElement("rcv_port", 993),
                        new XElement("snd_port", 587)
                        );
                setfile.Save("Settings.xml");
            }
            GetSettings();
            curr_client = new ImapClient("imap."+host, rcv_port, true, false);
            state = curr_client.Connect();
            if (state)
            {
                stateIndicator.ForeColor = Color.LightGreen;
                stateIndicator.Text = "Online";
            }
            else
            {
                stateIndicator.ForeColor = Color.Red;
                stateIndicator.Text = "Offline";
            }
        }
        public void GetSettings()
        {
            XDocument settings = XDocument.Load("Settings.xml");
            host = settings.Element("connect").Element("host").Value.ToString();
            rcv_port = int.Parse(settings.Element("connect").Element("rcv_port").Value);
            snd_port = int.Parse(settings.Element("connect").Element("snd_port").Value);
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
            if (curr_id != -1)
            {
                WriteForm write = new WriteForm(this);
                write.Show();
            }
            else
                MessageBox.Show("Для того чтобы написать письмо нужно авторизоваться", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void stateIndicator_Click(object sender, EventArgs e)
        {
            if (!curr_client.IsConnected)
            {
                if (curr_client.Connect())
                {
                    state = true;
                    stateIndicator.Text = curr_id != -1 ? emails[emails.FindIndex(em => em.id == curr_id)].Address : "Online";
                    stateIndicator.ForeColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Не удается подключиться. Проверьте подключение к сети!", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    state = false;
                    stateIndicator.Text = curr_id != -1 ? emails[emails.FindIndex(em => em.id == curr_id)].Address : "Offline";
                    stateIndicator.ForeColor = Color.Red;
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

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(this);
            settings.Show();
        }
    }
}
