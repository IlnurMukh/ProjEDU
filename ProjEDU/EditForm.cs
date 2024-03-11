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
            UpdateTrees();
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
        }

        private void btnAddNode1_Click(object sender, EventArgs e)
        {
            TreeNodeCollection tns = treeView1.Nodes;
            string lastNodeName = tns[tns.Count - 1].Name;
            var num = int.Parse(lastNodeName[^lastNodeName.Reverse().TakeWhile(char.IsDigit).Count()..]);
            string userAnswer = Microsoft.VisualBasic.Interaction.InputBox("Введите название новой темы", "Название темы", "Новая тема");
            TreeNode newNode = new TreeNode(userAnswer);
            newNode.Name = $"Node{num+1}";
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Text");
                doc = Content.ToXml(contentFirst.XMLText);
                XmlElement element = doc.CreateElement("node");
                element.SetAttribute("text", newNode.Text);
                element.SetAttribute("name", newNode.Name);
                XmlNode? root = doc.SelectNodes("//tree")[0];
                root.AppendChild(element);
                contentFirst.XMLText = doc.OuterXml;
                contentContext.SaveChanges();
                UpdateTrees();
            }
        }

        private void btnDel1_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Text");
                doc = Content.ToXml(contentFirst.XMLText);
                if (node.Name.Contains('_'))
                {
                    //TreeNode parentNode = node.Parent;
                    //int nodeIndex = int.Parse(parentNode.Name[^parentNode.Name.Reverse().TakeWhile(char.IsDigit).Count()..]);
                    //XmlNode? element = doc.SelectNodes("//node")[nodeIndex];
                    //int childIndex = int.Parse(node.Name[^node.Name.Reverse().TakeWhile(char.IsDigit).Count()..]);
                    //element.RemoveChild(element.SelectNodes("//childNode")[childIndex]);
                    var selected = doc.SelectSingleNode($"//node[@name = '{node.Parent.Name}']//childNode[@name = '{node.Name}']");
                    selected.ParentNode.RemoveChild(selected);
                }
                else
                {
                    var selected = doc.SelectSingleNode($"//node[@name = '{node.Name}']");
                    selected.ParentNode.RemoveChild(selected);
                }
                contentFirst.XMLText = doc.OuterXml;
                contentContext.SaveChanges();
            }
            UpdateTrees();
        }

        private void btnAddChild1_Click(object sender, EventArgs e)
        {
            string userAnswer = Microsoft.VisualBasic.Interaction.InputBox("Введите название подтемы", "Название подтемы", "Новая подтема");
            TreeNode node = treeView1.SelectedNode;
            int nodeIndex = int.Parse(node.Name[^node.Name.Reverse().TakeWhile(char.IsDigit).Count()..]);
            int num = node.Nodes.Count;
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Text");
                doc = Content.ToXml(contentFirst.XMLText);
                XmlElement element = doc.CreateElement("childNode");
                element.SetAttribute("text", userAnswer);
                element.SetAttribute("name", $"{node.Name}_{num}");
                element.SetAttribute("content", "Ваш текст");
                XmlNode xmlNode = doc.SelectNodes("//node")[nodeIndex];
                xmlNode.AppendChild(element);
                contentFirst.XMLText = doc.OuterXml;
                contentContext.SaveChanges();
            }
            UpdateTrees();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = treeView1.SelectedNode;
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList(); 
                Content contentFirst = contents.First(c => c.Type == "Text"); 
                doc = Content.ToXml(contentFirst.XMLText);
                
                bool founded = false;
                string content = "";
                for (int i = 0; i < doc.SelectNodes("//node").Count && !founded; i++)
                {
                    var node = doc.SelectNodes("//node")[i];
                    for (int j = 0; j < node.ChildNodes.Count && !founded; j++)
                    {
                        var child = node.ChildNodes[j];
                        if (child.Attributes["name"].Value == treeNode.Name)
                        {
                            child.Attributes["content"].Value = richTextBox1.Text;
                            contentFirst.XMLText = Content.ToString(doc);
                            contentContext.SaveChanges();
                            founded = true;
                        }
                    }
                }
            }
            UpdateTrees();
        }

        #endregion

        #region ImageTab

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e) { }
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            TreeNodeCollection tns = treeView2.Nodes;
            string lastNodeName = tns[tns.Count - 1].Name;
            var num = int.Parse(lastNodeName[^lastNodeName.Reverse().TakeWhile(char.IsDigit).Count()..]);
            string newNodeName = $"Node{num+1}";

            AddContentForm addContentForm = new AddContentForm(this);
            if (addContentForm.ShowDialog() == DialogResult.OK)
            {
                using (ContentContext contentContext = new ContentContext())
                {
                    XmlDocument doc = new XmlDocument();
                    List<Content> contents = contentContext.Contents.ToList();
                    Content contentFirst = contents.First(c => c.Type == "Image");
                    doc = Content.ToXml(contentFirst.XMLText);
                    XmlNode? root = doc.SelectNodes("//tree")[0];
                    XmlElement element = doc.CreateElement("node");
                    element.SetAttribute("title", ContentTitle);
                    element.SetAttribute("name", newNodeName);
                    element.SetAttribute("url", ContentURL);
                    root.AppendChild(element);
                    contentFirst.XMLText = doc.OuterXml;
                    contentContext.SaveChanges();
                }
                UpdateTrees();
            }
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView2.SelectedNode;

            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Image");
                doc = Content.ToXml(contentFirst.XMLText);
                var selected = doc.SelectSingleNode($"//node[@name = '{node.Name}']");
                selected.ParentNode.RemoveChild(selected);
                contentFirst.XMLText = doc.OuterXml;
                contentContext.SaveChanges();
            }
            UpdateTrees();
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView2.SelectedNode;
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Image");
                doc = Content.ToXml(contentFirst.XMLText);
                var selected = doc.SelectSingleNode($"//node[@name = '{node.Name}']");
                AddContentForm editContentForm =
                    new AddContentForm(this, selected["title"].Value, selected["url"].Value);
                if (editContentForm.ShowDialog() == DialogResult.OK)
                {
                    selected["title"].Value = ContentTitle;
                    selected["url"].Value = ContentURL;
                    contentFirst.XMLText = doc.OuterXml;
                    contentContext.SaveChanges();
                }
            }
            UpdateTrees();
        }


        #endregion

        #region VideoTab

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e) { }
        private void btnAdd3_Click(object sender, EventArgs e)
        {
            TreeNodeCollection tns = treeView2.Nodes;
            string lastNodeName = tns[tns.Count - 1].Name;
            var num = int.Parse(lastNodeName[^lastNodeName.Reverse().TakeWhile(char.IsDigit).Count()..]);
            string newNodeName = $"Node{num + 1}";

            AddContentForm addContentForm = new AddContentForm(this);
            if (addContentForm.ShowDialog() == DialogResult.OK)
            {
                using (ContentContext contentContext = new ContentContext())
                {
                    XmlDocument doc = new XmlDocument();
                    List<Content> contents = contentContext.Contents.ToList();
                    Content contentFirst = contents.First(c => c.Type == "Video");
                    doc = Content.ToXml(contentFirst.XMLText);
                    XmlNode? root = doc.SelectNodes("//tree")[0];
                    XmlElement element = doc.CreateElement("node");
                    element.SetAttribute("title", ContentTitle);
                    element.SetAttribute("name", newNodeName);
                    element.SetAttribute("url", ContentURL);
                    root.AppendChild(element);
                    contentFirst.XMLText = doc.OuterXml;
                    contentContext.SaveChanges();
                }
                UpdateTrees();
            }
        }

        private void btnDel3_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView3.SelectedNode;

            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Video");
                doc = Content.ToXml(contentFirst.XMLText);
                var selected = doc.SelectSingleNode($"//node[@name = '{node.Name}']");
                selected.ParentNode.RemoveChild(selected);
                contentFirst.XMLText = doc.OuterXml;
                contentContext.SaveChanges();
            }
            UpdateTrees();
        }

        private void btnEdit3_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView3.SelectedNode;
            XmlDocument doc = new XmlDocument();
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Video");
                doc = Content.ToXml(contentFirst.XMLText);
                var selected = doc.SelectSingleNode($"//node[@name = '{node.Name}']");
                AddContentForm editContentForm =
                    new AddContentForm(this, selected["title"].Value, selected["url"].Value);
                if (editContentForm.ShowDialog() == DialogResult.OK)
                {
                    selected["title"].Value = ContentTitle;
                    selected["url"].Value = ContentURL;
                    contentFirst.XMLText = doc.OuterXml;
                    contentContext.SaveChanges();
                }
            }
            UpdateTrees();
        }


        #endregion

        void UpdateTrees()
        {
            treeView1.Nodes.Clear();
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

            treeView2.Nodes.Clear();
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

            treeView3.Nodes.Clear();
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
    }
}
