using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ProjEDU.Model;

namespace ProjEDU
{
    public partial class MainForm : Form
    {
        public MainForm(string name, bool isTeacher)
        {
            InitializeComponent();
            if (!isTeacher)
            {
                editToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Visible = false;
            }
            Text = $"Вы вошли под логином {name}";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm();
            editForm.ShowDialog();
            Visible = false;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Text");
                doc = Content.ToXml(contentFirst.XMLText);
            }
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

            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Image");
                doc = Content.ToXml(contentFirst.XMLText);
            }
            foreach (XmlNode node in doc.SelectNodes("//node"))
            {
                var treeNode = new TreeNode();
                treeNode.Text = node.Attributes["title"].Value;
                treeNode.Name = node.Attributes["name"].Value;
                foreach (XmlNode child in node.ChildNodes)
                {
                    var childNode = new TreeNode();
                    childNode.Text = child.Attributes["title"].Value;
                    childNode.Name = child.Attributes["name"].Value;
                    treeNode.Nodes.Add(childNode);
                }
                treeView2.Nodes.Add(treeNode);
            }

            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Video");
                doc = Content.ToXml(contentFirst.XMLText);
            }
            foreach (XmlNode node in doc.SelectNodes("//node"))
            {
                var treeNode = new TreeNode();
                treeNode.Text = node.Attributes["title"].Value;
                treeNode.Name = node.Attributes["name"].Value;
                foreach (XmlNode child in node.ChildNodes)
                {
                    var childNode = new TreeNode();
                    childNode.Text = child.Attributes["title"].Value;
                    childNode.Name = child.Attributes["name"].Value;
                    treeNode.Nodes.Add(childNode);
                }
                treeView3.Nodes.Add(treeNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Text");
                doc = Content.ToXml(contentFirst.XMLText);
            }
            bool founded = false;
            string content = "";
            for (int i = 0; i < doc.SelectNodes("//node").Count && !founded; i++)
            {
                var node = doc.SelectNodes("//node")[i];
                for (int j = 0; j < node.ChildNodes.Count && !founded; j++)
                {
                    var child = node.ChildNodes[j];
                    if (child.Attributes["name"].Value == e.Node.Name)
                    {
                        content = child.Attributes["content"].Value;
                        founded = true;
                    }
                }
            }
            richTextBox1.Text = content;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Image");
                doc = Content.ToXml(contentFirst.XMLText);
            }
            bool founded = false;
            string url = "";
            for (int i = 0; i < doc.SelectNodes("//node").Count && !founded; i++)
            {
                var node = doc.SelectNodes("//node")[i];
                if (node.Attributes["name"].Value == e.Node.Name)
                {
                    url = node.Attributes["url"].Value;
                    founded = true;
                }
            }

            ProcessStartInfo processStartInfo = new ProcessStartInfo(url);
            processStartInfo.UseShellExecute = true;
            Process.Start(processStartInfo);
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Video");
                doc = Content.ToXml(contentFirst.XMLText);
            }
            bool founded = false;
            string url = "";
            for (int i = 0; i < doc.SelectNodes("//node").Count && !founded; i++)
            {
                var node = doc.SelectNodes("//node")[i];
                if (node.Attributes["name"].Value == e.Node.Name)
                {
                    url = node.Attributes["url"].Value;
                    founded = true;
                }
            }

            ProcessStartInfo processStartInfo = new ProcessStartInfo(url);
            processStartInfo.UseShellExecute = true;
            Process.Start(processStartInfo);
        }
    }
}
