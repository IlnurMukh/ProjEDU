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
    public partial class AddContentForm : Form
    {
        private string _title = "title";
        private string _url = "url";
        public AddContentForm(string title, string url)
        {
            InitializeComponent();
            title = _title;
            url = _url;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _title = tbTitle.Text;
            _url = tbURL.Text;
        }
    }
}
