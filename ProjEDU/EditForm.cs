﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjEDU
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        void SwitchPanels(Panel panel)
        {

        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Ilnur\\source\\repos\\ProjEDU\\ProjEDU\\XMLFiles\\TextTree.xml");
            //doc.Load("C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\XMLFiles\\TextTree.xml");
            foreach (XmlNode node in doc.SelectNodes("//node"))
            {
                var treeNode = new TreeNode();
                treeNode.Text = node.Attributes["text"].Value;
                treeNode.Name = node.Attributes["name"].Value;
                foreach (XmlNode child in node.ChildNodes)
                {
                    var childNode = new TreeNode();
                    childNode.Text = child.Attributes["text"].Value;
                    childNode.Name = child.Attributes["name"].Value;
                    treeNode.Nodes.Add(childNode);
                }
                treeView1.Nodes.Add(treeNode);
            }
        }
    }
}
