using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPop.Pop3;

namespace KursCrypt
{
    public partial class AuthForm : Form
    {
        BoxesForm Boxes;
        MainForm Main;
        public AuthForm(BoxesForm boxes)
        {
            Boxes = boxes;
            Main = boxes.Main;
            InitializeComponent();
        }
    }
}
