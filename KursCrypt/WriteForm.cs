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
    public partial class WriteForm : Form
    {
        MainForm Main;
        public WriteForm(MainForm main)
        {
            Main = main;
            InitializeComponent();
        }
    }
}
