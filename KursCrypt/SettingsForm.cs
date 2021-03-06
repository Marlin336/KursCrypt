﻿using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KursCrypt
{
    public partial class SettingsForm : Form
    {
        MainForm Main;

        public SettingsForm(MainForm main)
        {
            InitializeComponent();
            Main = main;
            num_rcv_port.Value = Main.rcv_port;
            num_snd_port.Value = Main.snd_port;
            num_msg_cntr.Value = Main.msg_cntr;
        }
        private void b_savesettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Настройки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                XElement setfile = new XElement(
                        "connect",
                        new XElement("rcv_port", num_rcv_port.Value),
                        new XElement("snd_port", num_snd_port.Value),
                        new XElement("msg_cntr", num_msg_cntr.Value)
                        );
                setfile.Save("Settings.xml");
                Main.GetSettings();
                Close();
            }
        }
        private void b_cancelsettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти без сохранения настроек?", "Настройки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
