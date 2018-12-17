using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace KursCrypt
{
    public partial class KeySwapForm : Form
    {
        MainForm Main;
        public KeySwapForm(MainForm main)
        {
            InitializeComponent();
            Main = main;
        }

        private void b_sentreq_Click(object sender, EventArgs e)
        {
            Regex rgx = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (!rgx.IsMatch(tb_email.Text))
            {
                MessageBox.Show("Неверно введённый E-mail адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (MessageBox.Show("Отправить запрос на обмен ключами?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }
            Email email_ref = Main.emails[Main.emails.FindIndex(em => em.id == Main.curr_id)];
            MailMessage requestMail = new MailMessage(new MailAddress(email_ref.Address, email_ref.Name), new MailAddress(tb_email.Text))
            {
                Subject = "ЗАПРОС ОБМЕНА КЛЮЧАМИ"
            };
            requestMail.Headers.Add("keyswap", "0");
            
            /*using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                XDocument doc = XDocument.Load("KeyHolder.xml");
                XElement userNode = doc.Element("body").Element("user");
                XElement recieverNode;
                while (userNode != null)
                {
                    if (userNode.Attribute("address").Value == email_ref.Address)
                    {
                        if (userNode.Element("recieverList").HasElements)
                        {
                            recieverNode = userNode.Element("recieverList");
                        }
                        else
                        {

                        }
                    }
                    userNode = (XElement)userNode.NextNode;
                }
            }*/
        }
    }
}

/*
 

XDocument document = XDocument.Load("Profile.xml");
XElement node = document.Element("body").Element("user");
while (node != null)
{
    if (node.Element("ads").Value == email_ref.Address)
    {
        node.Remove();
        document.Save("Profile.xml");
        break;
    }
    node = (XElement)node.NextNode;
            }
            
     
     */
