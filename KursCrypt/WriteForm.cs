using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mime;
using System.Security.Cryptography;

namespace KursCrypt
{
    public partial class WriteForm : Form
    {
        public struct Attach_elem
        {
            static int count = 0;
            public int id;
            public string path, name, extension;
            public double size;
            public Attach_elem(FileInfo file)
            {
                id = count++;
                path = file.FullName;
                name = file.Name;
                extension = file.Extension;
                size = Math.Round((double)file.Length / 1024, 2);//KB
            }
        } 

        MainForm Main;
        List<Attach_elem> attach_list = new List<Attach_elem>();
        List<string> recs = new List<string>();

        public WriteForm(MainForm main)
        {
            Main = main;
            InitializeComponent();
            Main.curr_client.Folders.Sent.Search("ALL", ImapX.Enums.MessageFetchMode.Headers, 25);
            List<string> hotRecips = new List<string>();
            var messages = Main.curr_client.Folders.Sent.Messages;
            for (int i = 0, count = 0; i < messages.Count() && count < 5; i++)
            {
                if (!hotRecips.Exists(str => str == messages[i].To[messages[i].To.Count - 1].Address))
                {
                    hotRecips.Add(messages[i].To[messages[i].To.Count - 1].Address);
                    count++;
                }    
            }
            foreach (var item in hotRecips)
                cb_to.Items.Add(item);
        }
        public WriteForm(MainForm main, string to, string subject) : this(main)
        {
            cb_to.Text = to;
            tb_subject.Text = subject;
        }
        private void b_addattach_Click(object sender, EventArgs e)
        {
            bool same = false;
            if (attach_fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] file_path = attach_fileDialog.FileNames;
                for (int i = 0; i <file_path.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(file_path[i]);
                    foreach (Attach_elem item in attach_list)
                    {
                        if (item.path.Equals(fileInfo.FullName))
                        {
                            same = true;
                            break;
                        }
                    }
                    if (!same)
                    {
                        attach_list.Add(new Attach_elem(fileInfo));
                        object[] vs = { attach_list[attach_list.Count - 1].id, attach_list[attach_list.Count - 1].path, attach_list[attach_list.Count - 1].name, attach_list[attach_list.Count - 1].extension, attach_list[attach_list.Count - 1].size };
                        list.Rows.Add(vs);
                    }
                    else
                        same = false;
                }
            }
        }
        private void b_delattach_Click(object sender, EventArgs e)
        {
            try
            {
                Attach_elem del_elem = new Attach_elem();
                for (int i = 0; i < attach_list.Count; i++)
                {
                    if (attach_list[i].id == (int)list.SelectedRows[0].Cells[0].Value)
                    {
                        del_elem = attach_list[i];
                        break;
                    }
                }
                list.Rows.RemoveAt(list.SelectedRows[0].Index);
                attach_list.Remove(del_elem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void b_send_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отправить сообщение?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> failRecip = new List<string>();
                try
                {
                    Email email_ref = Main.emails[Main.emails.FindIndex(em => em.id == Main.curr_id)];
                    string[] toList = cb_to.Text.Split();
                    string messageText = textBox.Text;
                    foreach (var recipient in toList)
                    {
                        try
                        {
                            if (CryptItem.Checked)
                            {
                                using (DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider())
                                {
                                    byte[] Key = desProvider.Key;
                                    byte[] IV = desProvider.IV;
                                    messageText = Convert.ToBase64String(Encryption.EncDES(messageText, Key, IV));
                                    messageText = Encryption.DecDES(Convert.FromBase64CharArray(messageText.ToArray(), 0, messageText.Length), Key, IV);
                                }     
                            }
                            MailMessage message = new MailMessage(new MailAddress(email_ref.Address, email_ref.Name), new MailAddress(recipient))
                            {
                                Subject = tb_subject.Text,
                                Body = messageText,
                            };
                            List<Attachment> attachments = new List<Attachment>();
                            foreach (var attach in attach_list)
                                message.Attachments.Add(new Attachment(attach.path, MediaTypeNames.Application.Octet));
                            SmtpClient smtp = new SmtpClient
                            {
                                Port = Main.snd_port,
                                Host = "smtp." + Main.host,
                                EnableSsl = true,
                                Timeout = 10000,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new System.Net.NetworkCredential(email_ref.Address, email_ref.Password)
                            };
                            smtp.Send(message);
                        }
                        catch (SmtpFailedRecipientException exRecip)
                        {
                            failRecip.Add(exRecip.FailedRecipient);
                        }
                    }
                    if (failRecip.Count != 0)
                    {
                        string except = null;
                        foreach (var item in failRecip)
                            except += item + "\n";
                        MessageBox.Show("Не удалось отправить сообщение данным пользователям:\n" + except, "Ошибка отправки сообщения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CryptItem_Click(object sender, EventArgs e)
        {
            CryptItem.Checked = !CryptItem.Checked;
        }

        private void SignItem_Click(object sender, EventArgs e)
        {
            SignItem.Checked = !SignItem.Checked;
        }
    }
}
