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
    public partial class BoxesForm : Form
    {
        public MainForm Main;
        public BoxesForm(MainForm main)
        {
            Main = main;
            InitializeComponent();
        }

        private void lb_boxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            b_del.Enabled = lb_boxes.SelectedIndex != -1;
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            AuthForm auth = new AuthForm(this);
            auth.ShowDialog();
        }
    }
}
