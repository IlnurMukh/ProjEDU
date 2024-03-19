using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
        Panel[] panelList;
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

            ////////////////////////////////////////////////////////////////////////
            doc.Load("C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\Test.xml");
            foreach (XmlNode node in doc.SelectNodes("//question"))
            {
                var treeNode = new TreeNode();
                treeNode.Text = $"{node.Attributes["id"].Value} вопрос";
                treeNode.Name = node.Attributes["id"].Value;
                treeView4.Nodes.Add(treeNode);
            }
            XmlElement root = doc.DocumentElement;
            if (root != null)
            {
                panelList = new Panel[doc.SelectNodes("//question").Count+1];
                foreach (XmlElement node in root)
                {
                    if (treeView4.Nodes.ContainsKey(node.Attributes["id"].Value))
                    {
                        int id = int.Parse(node.Attributes["id"].Value);
                        Panel panelTest = new Panel();
                        tabPage4.Controls.Add(panelTest);
                        panelTest.Location = new Point(215, 3);
                        panelTest.Size = new Size(1046, 379);
                        panelTest.Name = node.Attributes["id"].Value;
                        panelTest.Visible = false;
                        panelList[id] = panelTest;
                        Label lblQestion = new Label();
                        lblQestion.Location = new Point(17, 17);
                        lblQestion.Text = node.Attributes["qtext"].Value;
                        lblQestion.AutoSize = true;
                        panelTest.Controls.Add(lblQestion);

                        if (node.Attributes["type"].Value == "1")
                        {
                            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
                            panelTest.Controls.Add(tableLayoutPanel1);
                            RadioButton radioButton1 = new RadioButton();
                            RadioButton radioButton2 = new RadioButton();
                            RadioButton radioButton3 = new RadioButton();
                            RadioButton radioButton4 = new RadioButton();
                            radioButton1.AutoSize = true;
                            radioButton1.Location = new Point(3, 3);
                            radioButton1.Size = new Size(117, 24);
                            radioButton1.TabIndex = 1;
                            radioButton1.TabStop = true;
                            radioButton1.Text = "radioButton1";
                            radioButton1.UseVisualStyleBackColor = true;
                            radioButton4.AutoSize = true;
                            radioButton4.Location = new Point(3, 96);
                            radioButton4.Size = new Size(117, 24);
                            radioButton4.TabIndex = 4;
                            radioButton4.TabStop = true;
                            radioButton4.Text = "radioButton4";
                            radioButton4.UseVisualStyleBackColor = true;
                            radioButton2.AutoSize = true;
                            radioButton2.Location = new Point(3, 34);
                            radioButton2.Size = new Size(117, 24);
                            radioButton2.TabIndex = 2;
                            radioButton2.TabStop = true;
                            radioButton2.Text = "radioButton2";
                            radioButton2.UseVisualStyleBackColor = true;
                            radioButton3.AutoSize = true;
                            radioButton3.Location = new Point(3, 65);
                            radioButton3.Size = new Size(117, 24);
                            radioButton3.TabIndex = 3;
                            radioButton3.TabStop = true;
                            radioButton3.Text = "radioButton3";
                            radioButton3.UseVisualStyleBackColor = true;

                            radioButton1.Name = "1";
                            radioButton2.Name = "2";
                            radioButton3.Name = "3";
                            radioButton4.Name = "4";
                            tableLayoutPanel1.ColumnCount = 1;
                            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                            tableLayoutPanel1.Controls.Add(radioButton1, 0, 0);
                            tableLayoutPanel1.Controls.Add(radioButton2, 0, 1);
                            tableLayoutPanel1.Controls.Add(radioButton3, 0, 2);
                            tableLayoutPanel1.Controls.Add(radioButton4, 0, 3);
                            tableLayoutPanel1.Location = new Point(17, 73);
                            tableLayoutPanel1.Name = "tableLayoutPanel1";
                            tableLayoutPanel1.RowCount = 4;
                            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                            tableLayoutPanel1.Size = new Size(250, 125);
                            tableLayoutPanel1.TabIndex = 6;
                            foreach(XmlNode childnode in node.ChildNodes)
                            {
                                foreach(var control in tableLayoutPanel1.Controls)
                                {
                                    if(control is RadioButton && 
                                        ((RadioButton)control).Parent == tableLayoutPanel1 && 
                                        tableLayoutPanel1.Parent == panelList[id] &&
                                        childnode.Attributes.Count > 1 &&
                                        ((RadioButton)control).Name == childnode.Attributes["id"].Value)
                                    {
                                        ((RadioButton)control).Text = childnode.Attributes["text"].Value;
                                    }
                                }
                            }
                        }
                        if (node.Attributes["type"].Value == "2")
                        {

                        }
                        if (node.Attributes["type"].Value == "3")
                        {

                        }
                        if (node.Attributes["type"].Value == "4")
                        {

                        }

                    }

                }
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
        /////////////////////////////////////////////////////////////////////
        private void treeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\Test.xml");
            XmlElement root = doc.DocumentElement;
            if(root != null)
            {
                foreach(XmlElement node in root)
                {
                    if (node.Attributes["id"].Value == e.Node.Name)
                    {
                        panelList[int.Parse(e.Node.Name)].Visible = true;
                    }
                    //if (node.Attributes["type"].Value == "1")
                    //{
                    //    panel1.Visible = true;
                    //    if (node.Attributes["id"].Value == e.Node.Name)
                    //    {
                    //        label1.Text = node.Attributes["qtext"].Value;
                    //        foreach (XmlNode childNode in node.ChildNodes)
                    //        {

                    //        }
                    //    }
                    //}
                    //if (node.Attributes["id"].Value == e.Node.Name)
                    //{
                    //    Panel panel = new Panel();
                    //    tabPage4.Controls.Add(panel);
                    //    panel.Location = new Point(215, 3);
                    //    panel.Size = new Size(1046, 379);
                    //    panel.Name = e.Node.Name;


                    //}

                }
            }
        }
    }
}
