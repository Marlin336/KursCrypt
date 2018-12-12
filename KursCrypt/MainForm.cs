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
        public Email(string address, string password, string name)
        {
            id = count++;
            Address = address;
            Password = password;
            Name = name;
        }
    }
    public enum Folder { inbox, sent, junk, trash};
    public partial class MainForm : Form
    {
        public int rcv_port { get; private set; }
        public int snd_port { get; private set; }
        public string host { get; set; }
        public List<Email> emails = new List<Email>();
        public int curr_id { get; set; } = -1;
        public ImapClient curr_client = null;
        public Folder curr_fold { get; private set; } = Folder.inbox;

        public MainForm()
        {
            InitializeComponent();
            if(!File.Exists("Settings.xml"))
            { 
                MessageBox.Show("Файл настроек не найден. Настройки будут сброшены до дефолтных", "Файл настроек не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XElement setfile = new XElement(
                        "connect",
                        new XElement("rcv_port", 993),
                        new XElement("snd_port", 587)
                        );
                setfile.Save("Settings.xml");
            }
            GetSettings();
            if (!File.Exists("Profile.xml"))
            {
                XElement profile = new XElement("body",null);
                profile.Save("Profile.xml");
            }
            else
            {
                XDocument profile = XDocument.Load("Profile.xml");
                XElement node;
                if (!profile.Element("body").IsEmpty)
                {
                    node = profile.Element("body").Element("user");
                    while (node != null)
                    {
                        emails.Add(new Email(node.Element("ads").Value,
                        node.Element("pwd").Value,
                        node.Element("nm").Value));
                        node = (XElement)node.NextNode;
                    } 
                }
            }
        }
        public void GetSettings()
        {
            XDocument settings = XDocument.Load("Settings.xml");
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
            if (curr_client != null && curr_client.IsConnected)
                RedrawMailList();
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
            if (curr_client == null)
                return;
            grid_messlist.Rows.Clear();
            switch (curr_fold)
            {
                case Folder.inbox:
                    curr_client.Folders.Inbox.Search("ALL", ImapX.Enums.MessageFetchMode.ClientDefault, 25);
                    foreach (var item in curr_client.Folders.Inbox.Messages)
                    {
                        object[] row = { item.UId, item.From.Address, item.From.DisplayName, item.Subject, item.Date, item.Attachments.Length };
                        grid_messlist.Rows.Add(row);
                    }
                    break;
                case Folder.sent:
                    curr_client.Folders.Sent.Search("ALL", ImapX.Enums.MessageFetchMode.ClientDefault, 25);
                    foreach (var item in curr_client.Folders.Sent.Messages)
                    {
                        object[] row = { item.UId, item.From.Address, item.From.DisplayName, item.Subject, item.Date, item.Attachments.Length };
                        grid_messlist.Rows.Add(row);
                    }
                    break;
                case Folder.junk:
                    curr_client.Folders.Junk.Search("ALL", ImapX.Enums.MessageFetchMode.ClientDefault, 25);
                    foreach (var item in curr_client.Folders.Junk.Messages)
                    {
                        object[] row = { item.UId, item.From.Address, item.From.DisplayName, item.Subject, item.Date, item.Attachments.Length };
                        grid_messlist.Rows.Add(row);
                    }
                    break;
                case Folder.trash:
                    curr_client.Folders.Trash.Search("ALL", ImapX.Enums.MessageFetchMode.ClientDefault, 25);
                    foreach (var item in curr_client.Folders.Trash.Messages)
                    {
                        object[] row = { item.UId, item.From.Address, item.From.DisplayName, item.Subject, item.Date, item.Attachments.Length };
                        grid_messlist.Rows.Add(row);
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
        private void grid_messlist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReadForm read;
            switch (curr_fold)
            {
                case Folder.inbox:
                    read = new ReadForm(this, curr_client.Folders.Inbox, (long)grid_messlist.SelectedRows[0].Cells[0].Value);
                    break;
                case Folder.sent:
                    read = new ReadForm(this, curr_client.Folders.Sent, (long)grid_messlist.SelectedRows[0].Cells[0].Value);
                    break;
                case Folder.junk:
                    read = new ReadForm(this, curr_client.Folders.Junk, (long)grid_messlist.SelectedRows[0].Cells[0].Value);
                    break;
                case Folder.trash:
                    read = new ReadForm(this, curr_client.Folders.Trash, (long)grid_messlist.SelectedRows[0].Cells[0].Value);
                    break;
                default:
                    read = new ReadForm(this, curr_client.Folders.All, 0);
                    break;
            }
            read.Show();
        }
    }
}