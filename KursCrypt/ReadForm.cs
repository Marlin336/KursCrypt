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
    public partial class ReadForm : Form
    {
        MainForm Main;
        long uid;
        public ImapX.Message message { get; private set; }

        public ReadForm(MainForm main, ImapX.Folder folder, long uid)
        {
            InitializeComponent();
            Main = main;
            this.uid = uid;
            message = folder.Messages.First(msg => msg.UId == uid);
            tb_opentext.Text = message.Body.Text;
            tb_subject.Text = message.Subject;
            tb_from.Text = message.From.DisplayName + " <" + message.From.Address + ">";
            b_attach.Enabled = message.Attachments.Length > 0;
            string cryptflags;
            if(message.Headers.TryGetValue("crypt", out cryptflags)) //Есть флаги-признаки шифрования
            {
                byte cryptF = byte.Parse(cryptflags);
                if ((cryptF & 2) != 0)//Флаг шифрования
                {
                    byte[] Key = Convert.FromBase64String(message.Headers["dsakey"]);
                    byte[] IV = Convert.FromBase64String(message.Headers["dsaiv"]);
                    var a = message.Body.Text.Substring(0, message.Body.Text.IndexOf("\r")) + "=";
                    tb_opentext.Text = Encryption.DecDES(Convert.FromBase64String(a), Key, IV);
                }          
            }
        }
        private void b_attach_Click(object sender, EventArgs e)
        {
            InAttachForm attachForm = new InAttachForm(message);
            attachForm.Show();
        }
        private void b_reply_Click(object sender, EventArgs e)
        {
            string addressee = tb_from.Text.Substring(tb_from.Text.IndexOf('<') + 1);
            addressee = addressee.Substring(0, addressee.Length - 1);
            WriteForm write = new WriteForm(Main, addressee, "Re:" + tb_subject.Text);
            write.ShowDialog();
        }
    }
}
