﻿using System;
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
using ProjEDU.Model;

namespace ProjEDU
{
    public partial class EditForm : Form
    {
        public string ContentTitle { get; set; }
        public string ContentURL { get; set; }
        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
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
        }


        #region TextTab

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
            btnAddChild1.Enabled = !e.Node.Name.Contains('_');
            TreeNodeCollection tns = treeView1.Nodes;
            foreach (TreeNode node in tns) { }
        }

        private void btnAddNode1_Click(object sender, EventArgs e)
        {

        }

        private void btnDel1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddChild1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region ImageTab

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
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            //AddContentForm addContentForm = new AddContentForm(this);
            //if (addContentForm.ShowDialog() == DialogResult.OK)
            //{
            //    XmlDocument doc = new XmlDocument();
            //    XmlElement root = doc.CreateElement("tree");
            //    doc.AppendChild(root);
            //    XmlElement element = doc.CreateElement("node");
            //    element.SetAttribute("title", ContentTitle);
            //    element.SetAttribute("name", "Node0");
            //    element.SetAttribute("url", ContentURL);
            //    root.AppendChild(element);
            //    using (ContentContext contentContext = new ContentContext())
            //    {
            //        contentContext.Contents.Add(new Content()
            //        {
            //            Type = "Image", XMLText = Content.ToString(doc)
            //        });
            //        contentContext.SaveChanges();
            //    }
            //}
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave2_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region VideoTab

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void btnAdd3_Click(object sender, EventArgs e)
        {

        }

        private void btnDel3_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave3_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
