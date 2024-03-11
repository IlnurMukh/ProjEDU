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
        private readonly EditForm _form;
        public AddContentForm(EditForm form)
        {
            InitializeComponent();
            _form = form;
        }

        public AddContentForm(EditForm form, string title, string url)
        {
            InitializeComponent();
            _form = form;
            tbTitle.Text = title;
            tbURL.Text = url;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _form.ContentTitle = tbTitle.Text;
            _form.ContentURL = tbURL.Text;
        }
    }
}
