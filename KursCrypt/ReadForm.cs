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
    public partial class ReadForm : Form
    {
        MainForm Main;
        long uid;
        ImapX.Message message;
        public ReadForm(MainForm main, ImapX.Folder folder, long uid)
        {
            InitializeComponent();
            Main = main;
            this.uid = uid;
            foreach (var item in folder.Messages)
            {
                if (item.UId == uid)
                {
                    message = item;
                    break;
                }
            }
            tb_opentext.Text = message.Body.Text;
            tb_subject.Text = message.Subject;
            tb_from.Text = message.From.DisplayName + " <" + message.From.Address + ">";
            b_attach.Enabled = message.Attachments.Length > 0;
        }
    }
}
