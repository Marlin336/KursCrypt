﻿using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

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
        public int msg_cntr { get; set; }
        public List<Email> emails = new List<Email>();
        public int curr_id { get; set; } = -1;
        public ImapClient curr_client = null;
        public Folder curr_fold { get; private set; } = Folder.inbox;
        public KeyHolder KeyHolders;

        public MainForm()
        {
            InitializeComponent();
            if(!File.Exists("Settings.xml"))
            { 
                MessageBox.Show("Файл настроек не найден. Настройки будут сброшены до дефолтных", "Файл настроек не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XElement setfile = new XElement(
                        "connect",
                        new XElement("rcv_port", 993),
                        new XElement("snd_port", 587),
                        new XElement("msg_cntr", 25)
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
            XmlSerializer serializer = new XmlSerializer(typeof(KeyHolder));
            if (!File.Exists("KeyHolder.xml"))
            {
                using (FileStream fs = new FileStream("KeyHolder.xml", FileMode.Create))
                {
                    serializer.Serialize(fs, new KeyHolder());
                }
            }     
            using (FileStream fs = new FileStream("KeyHolder.xml", FileMode.Open))
            {
                KeyHolders = (KeyHolder)serializer.Deserialize(fs);
            }
        }
        public void GetSettings()
        {
            XDocument settings = XDocument.Load("Settings.xml");
            rcv_port = int.Parse(settings.Element("connect").Element("rcv_port").Value);
            snd_port = int.Parse(settings.Element("connect").Element("snd_port").Value);
            msg_cntr = int.Parse(settings.Element("connect").Element("msg_cntr").Value);
        }
        private void почтовыеЯщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxesForm boxes = new BoxesForm(this);
            boxes.ShowDialog();
        }
        private void написатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Write_message();
        }
        private void Write_message()
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
            Email email_ref = emails.Find(em => em.id == curr_id);
            if (curr_client != null && curr_client.IsConnected)
                RedrawMailList(email_ref.Address);
        }
        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email email_ref = emails.Find(em => em.id == curr_id);
            отправленныеToolStripMenuItem.Checked = спамToolStripMenuItem.Checked = корзинаToolStripMenuItem.Checked = false;
            входящиеToolStripMenuItem.Checked = true;
            curr_fold = Folder.inbox;
            RedrawMailList(email_ref.Address);
        }
        private void отправленныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email email_ref = emails.Find(em => em.id == curr_id);
            входящиеToolStripMenuItem.Checked = спамToolStripMenuItem.Checked = корзинаToolStripMenuItem.Checked = false;
            отправленныеToolStripMenuItem.Checked = true;
            curr_fold = Folder.sent;
            RedrawMailList(email_ref.Address);
        }
        private void спамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email email_ref = emails.Find(em => em.id == curr_id);
            входящиеToolStripMenuItem.Checked = отправленныеToolStripMenuItem.Checked = корзинаToolStripMenuItem.Checked = false;
            спамToolStripMenuItem.Checked = true;
            curr_fold = Folder.junk;
            RedrawMailList(email_ref.Address);
        }
        private void корзинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email email_ref = emails.Find(em => em.id == curr_id);
            входящиеToolStripMenuItem.Checked = спамToolStripMenuItem.Checked = отправленныеToolStripMenuItem.Checked = false;
            корзинаToolStripMenuItem.Checked = true;
            curr_fold = Folder.trash;
            RedrawMailList(email_ref.Address);
        }
        public void RedrawMailList(string client_address)
        {
            if (curr_id == -1) 
                return;
            try
            {
                Email email_ref = emails.Find(em => em.id == curr_id);
                string dir = Directory.CreateDirectory("Saved/" + client_address + "/" + curr_fold.ToString()).FullName;
                var fullnames = Directory.GetFiles(dir);
                for (int i = 0; i < fullnames.Length; i++)
                {
                    fullnames[i] = fullnames[i].Substring(fullnames[i].LastIndexOf('\\') + 1);
                }
                switch (curr_fold)
                {
                    case Folder.inbox:
                        grid_messlist.Rows.Clear();
                        try
                        {
                            curr_client.Inbox.Open(FolderAccess.ReadOnly);
                            foreach (var item in curr_client.Inbox.Fetch(0, msg_cntr - 1, MessageSummaryItems.All | MessageSummaryItems.BodyStructure))
                            {
                                object[] row = { item.Envelope.MessageId, item.Envelope.From.Mailboxes.First().Address, item.Envelope.From[0].Name, item.Envelope.Subject, item.Date.LocalDateTime, item.Attachments.Count() };
                                grid_messlist.Rows.Add(row);
                                if (!fullnames.Contains(item.Envelope.MessageId))
                                {
                                    try
                                    {
                                        curr_client.Inbox.First(msg => msg.MessageId == item.Envelope.MessageId).WriteTo(FormatOptions.Default, dir + "/" + item.Envelope.MessageId);
                                    }
                                    catch (Exception) { continue; }
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            if (curr_client == null)
                            {
                                foreach (var item in Directory.EnumerateFiles(dir))
                                {
                                    MimeMessage msg = MimeMessage.Load(item);
                                    object[] row = { msg.MessageId, msg.From.Mailboxes.First().Address, msg.From[0].Name, msg.Subject, msg.Date.LocalDateTime, msg.Attachments.Count() };
                                    grid_messlist.Rows.Add(row);
                                }
                            }
                        }
                        break;
                    case Folder.sent:
                        grid_messlist.Rows.Clear();
                        try
                        {
                            curr_client.GetFolder(SpecialFolder.Sent).Open(FolderAccess.ReadOnly);
                            foreach (var item in curr_client.GetFolder(SpecialFolder.Sent).Fetch(0, msg_cntr -1, MessageSummaryItems.All | MessageSummaryItems.BodyStructure))
                            {
                                object[] row = { item.Envelope.MessageId, item.Envelope.From.Mailboxes.First().Address, item.Envelope.From[0].Name, item.Envelope.Subject, item.Date.LocalDateTime, item.Attachments.Count() };
                                grid_messlist.Rows.Add(row);
                                if (!fullnames.Contains(item.Envelope.MessageId))
                                {
                                    try
                                    {
                                        curr_client.GetFolder(SpecialFolder.Sent).First(msg => msg.MessageId == item.Envelope.MessageId).WriteTo(FormatOptions.Default, dir + "/" + item.Envelope.MessageId);
                                    }
                                    catch (Exception) { continue; }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            if (curr_client == null)
                            {
                                foreach (var item in Directory.EnumerateFiles(dir))
                                {
                                    MimeMessage msg = MimeMessage.Load(item);
                                    object[] row = { msg.MessageId, msg.From.Mailboxes.First().Address, msg.From[0].Name, msg.Subject, msg.Date.LocalDateTime, msg.Attachments.Count() };
                                    grid_messlist.Rows.Add(row);
                                }
                            }
                        }
                        break;
                    case Folder.junk:
                        grid_messlist.Rows.Clear();
                        try
                        {
                            curr_client.GetFolder(SpecialFolder.Junk).Open(FolderAccess.ReadOnly);
                            foreach (var item in curr_client.GetFolder(SpecialFolder.Junk).Fetch(0, msg_cntr - 1, MessageSummaryItems.All | MessageSummaryItems.BodyStructure))
                            {
                                object[] row = { item.Envelope.MessageId, item.Envelope.From.Mailboxes.First().Address, item.Envelope.From[0].Name, item.Envelope.Subject, item.Date.LocalDateTime, item.Attachments.Count() };
                                grid_messlist.Rows.Add(row);
                                if (!fullnames.Contains(item.Envelope.MessageId))
                                {
                                    try
                                    {
                                        curr_client.GetFolder(SpecialFolder.Junk).First(msg => msg.MessageId == item.Envelope.MessageId).WriteTo(FormatOptions.Default, dir + "/" + item.Envelope.MessageId);
                                    }
                                    catch (Exception) { continue; }
                                }
                            }
                        }
                        catch(Exception)
                        {
                            if (curr_client == null)
                            {
                                foreach (var item in Directory.EnumerateFiles(dir))
                                {
                                    MimeMessage msg = MimeMessage.Load(item);
                                    object[] row = { msg.MessageId, msg.From.Mailboxes.First().Address, msg.From[0].Name, msg.Subject, msg.Date.LocalDateTime, msg.Attachments.Count() };
                                    grid_messlist.Rows.Add(row);
                                }
                            }
                        }
                        break;
                    case Folder.trash:
                        grid_messlist.Rows.Clear();
                        try
                        {
                            curr_client.GetFolder(SpecialFolder.Trash).Open(FolderAccess.ReadOnly);
                            foreach (var item in curr_client.GetFolder(SpecialFolder.Trash).Fetch(0, msg_cntr - 1, MessageSummaryItems.All | MessageSummaryItems.BodyStructure))
                            {
                                object[] row = { item.Envelope.MessageId, item.Envelope.From.Mailboxes.First().Address, item.Envelope.From[0].Name, item.Envelope.Subject, item.Date.LocalDateTime, item.Attachments.Count() };
                                grid_messlist.Rows.Add(row);
                                if (!fullnames.Contains(item.Envelope.MessageId))
                                {
                                    try
                                    {
                                        curr_client.GetFolder(SpecialFolder.Trash).First(msg => msg.MessageId == item.Envelope.MessageId).WriteTo(FormatOptions.Default, dir + "/" + item.Envelope.MessageId);
                                    }
                                    catch (Exception) { continue; }
                                }
                            }
                        }
                        catch(Exception)
                        {
                            if (curr_client == null)
                            {
                                foreach (var item in Directory.EnumerateFiles(dir))
                                {
                                    MimeMessage msg = MimeMessage.Load(item);
                                    object[] row = { msg.MessageId, msg.From.Mailboxes.First().Address, msg.From[0].Name, msg.Subject, msg.Date.LocalDateTime, msg.Attachments.Count() };
                                    grid_messlist.Rows.Add(row);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(this);
            settings.Show();
        }
        private void grid_messlist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReadForm read = new ReadForm(this, curr_fold, grid_messlist.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                read.Show();
            }
            catch (Exception) { }
        }
        private void grid_messlist_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currMousOverRow = grid_messlist.HitTest(e.X, e.Y).RowIndex;
                if (currMousOverRow != -1)
                {
                    grid_messlist.Rows[currMousOverRow].Selected = true;
                    con_menu.Items[2].Enabled = (int)grid_messlist.SelectedRows[0].Cells[5].Value > 0;
                }
                if (currMousOverRow != -1)
                    con_menu.Show(grid_messlist, new Point(e.X, e.Y));
            }
        }
        private void прочитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid_messlist_CellDoubleClick(null, null);
        }
        private void ответитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteForm write = new WriteForm(this, grid_messlist.SelectedRows[0].Cells[1].Value.ToString(), "Re:" + grid_messlist.SelectedRows[0].Cells[3].Value.ToString());
            write.Show();
        }
        private void посмотретьВложенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadForm read = new ReadForm(this, curr_fold, grid_messlist.SelectedRows[0].Cells[0].Value.ToString());
            InAttachForm attachForm = new InAttachForm(read.message);
            attachForm.Show();
        }
        private void обменКлючамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curr_id != -1)
            {
                KeySwapForm swapForm = new KeySwapForm(this);
                swapForm.Show();
            }
            else
            {
                MessageBox.Show("Для обмена ключами нужно авторизоваться", "Необходима авторизация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void SerializeKeyFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(KeyHolder));
            if (File.Exists("KeyHolder.xml"))
            {
                using (FileStream fs = new FileStream("KeyHolder.xml", FileMode.Create))
                {
                    serializer.Serialize(fs, KeyHolders);
                }
            }
        }
        public KeyHolder DeserilizeKeyFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(KeyHolder));
            using (FileStream fs = new FileStream("KeyHolder.xml", FileMode.Open))
            {
                return (KeyHolder)serializer.Deserialize(fs);
            }
        }
    }
}