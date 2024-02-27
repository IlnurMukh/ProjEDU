using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjEDU
{
    public partial class MainForm : Form
    {
        public MainForm(string name)
        {
            InitializeComponent();
            Text = $"Вы вошли под логином {name}";
        }

        private void theoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int c;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
