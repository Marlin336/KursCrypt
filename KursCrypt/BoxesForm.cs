using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ImapX;

namespace KursCrypt
{
    public partial class BoxesForm : Form
    {
        public MainForm Main;

        public BoxesForm(MainForm main)
        {
            Main = main;
            InitializeComponent();
            foreach (Email item in main.emails)
            {
                object[] row = { item.id, item.Address };
                grid_boxes.Rows.Add(row);
            }
        }
        private void b_add_Click(object sender, EventArgs e)
        {
            AuthForm auth = new AuthForm(this);
            auth.ShowDialog();
        }
        public void AddToBoxlist(Email email)
        {
            object[] row = { email.id, email.Address };
            grid_boxes.Rows.Add(row);
        }
        private void b_del_Click(object sender, EventArgs e)
        {
            Email email_ref = Main.emails[Main.emails.FindIndex(em => em.id == (int)grid_boxes.SelectedRows[0].Cells[0].Value)];
            Main.emails.Remove(email_ref);
            grid_boxes.Rows.RemoveAt(grid_boxes.SelectedRows[0].Index);
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
        }
        private void grid_boxes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Email email_ref = Main.emails[Main.emails.FindIndex(em => em.id == (int)grid_boxes.SelectedRows[0].Cells[0].Value)];
            Main.host = email_ref.Address.Substring(email_ref.Address.IndexOf('@') + 1);
            ImapClient client = new ImapClient("imap." + Main.host, Main.rcv_port, true, false);
            if (client.Connect())
            {
                client.Login(email_ref.Address, email_ref.Password);
                Main.curr_client = client;
                Main.curr_id = email_ref.id;
                Main.stateIndicator.Text = email_ref.Address;
                List<string> headersList = Main.curr_client.Behavior.RequestedHeaders.ToList();
                headersList.Add("crypt");
                headersList.Add("dsaKey");
                headersList.Add("dsaIV");
                Main.curr_client.Behavior.RequestedHeaders = headersList.ToArray();
                Close();
                Main.RedrawMailList();
            }
            else
            {
                MessageBox.Show("Ошибка поключения. Проверьте соединение с сетью!", "Ошибка сети", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
