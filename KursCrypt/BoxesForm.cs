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
            foreach (Email item in main.emails)
            {
                object[] row = { item.id, item.Login };
                grid_boxes.Rows.Add(row);
            }
            grid_boxes_RowsCountChange();
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            AuthForm auth = new AuthForm(this);
            auth.ShowDialog();
        }

        public void AddToBoxlist(Email email)
        {
            object[] row = { email.id, email.Login };
            grid_boxes.Rows.Add(row);
        }

        private void grid_boxes_RowsCountChange()
        {
            b_del.Enabled = grid_boxes.RowCount != 0;
        }

        private void grid_boxes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            grid_boxes_RowsCountChange();
        }

        private void grid_boxes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            grid_boxes_RowsCountChange();
        }

        private void b_del_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Main.emails.Count; i++)
            {
                if (Main.emails[i].id == (int)grid_boxes.SelectedRows[0].Cells[0].Value)
                {
                    Main.emails.RemoveAt(i);
                    grid_boxes.Rows.RemoveAt(grid_boxes.SelectedRows[0].Index);
                    break;
                }
            }
        }
    }
}
