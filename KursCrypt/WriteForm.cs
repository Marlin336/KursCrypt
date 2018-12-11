using ImapX;
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
using System.Net.Mail;
using System.Net.Mime;

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
        ImapClient client;
        List<Attach_elem> attach_list = new List<Attach_elem>();
        public WriteForm(MainForm main)
        {
            Main = main;
            client = Main.curr_client;
            InitializeComponent();
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
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_send_Click(object sender, EventArgs e)
        {
            Email email_ref = Main.emails[Main.emails.FindIndex(em => em.id == Main.curr_id)];
            MailMessage message = new MailMessage(email_ref.Login, cb_to.Text, tb_subject.Text, textBox.Text);
            List<System.Net.Mail.Attachment> attachments = new List<System.Net.Mail.Attachment>();
            foreach (var item in attach_list)
                message.Attachments.Add(new System.Net.Mail.Attachment(item.path, MediaTypeNames.Application.Octet));
            SmtpClient smtp = new SmtpClient(Main.curr_client.Host, 25);
            try
            {
                smtp.Send(message);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
