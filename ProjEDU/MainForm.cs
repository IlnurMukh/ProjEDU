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


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var authForm = new AuthForm();
            ////authForm.Closed += (_, _) => this.Close();
            ////this.Hide();
            //this.Close();
            //authForm.ShowDialog();
            DialogResult = DialogResult.OK;
        }
    }
}
