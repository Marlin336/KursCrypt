﻿using System;
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

        private void grid_boxes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < Main.emails.Count; i++)
            {
                if (Main.emails[i].id == (int)grid_boxes.SelectedRows[0].Cells[0].Value)
                {
                    Main.curr_client.Login(Main.emails[i].Login, Main.emails[i].Password);
                    Main.curr_email = Main.emails[i].id;
                    Close();
                    Main.RedrawMailList();
                    break;
                }
            }
        }
    }
}
