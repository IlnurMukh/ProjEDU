using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

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
            Visible = false;
        }
        

        private void MainForm_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Ilnur\\source\\repos\\ProjEDU\\ProjEDU\\XMLFiles\\TextTree.xml");
            //doc.Load("C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\XMLFiles\\TextTree.xml");
            foreach (XmlNode node in doc.SelectNodes("//node"))
            {
                var treeNode = new TreeNode();
                treeNode.Text = node.Attributes["text"].Value;
                treeNode.Name = node.Attributes["name"].Value;
                foreach(XmlNode child in node.ChildNodes)
                {
                    var childNode = new TreeNode();
                    childNode.Text = child.Attributes["text"].Value;
                    childNode.Name = child.Attributes["name"].Value;
                    treeNode.Nodes.Add(childNode);
                }
                treeView1.Nodes.Add(treeNode);
            }
        }

        private void btnTheory_Click(object sender, EventArgs e)
        {
            pnlTheoryTest.Visible = false;

        }

       

        private void btnForward_Click(object sender, EventArgs e)
        {
            //XmlDocument doc = new XmlDocument();
            //XmlElement root = doc.CreateElement("tree");
            //doc.AppendChild(root);

            //for (int i = 0; i < treeView1.Nodes.Count; i++)
            //{
            //    XmlElement element = doc.CreateElement("node");
            //    element.SetAttribute("text", treeView1.Nodes[i].Text);
            //    element.SetAttribute("name", treeView1.Nodes[i].Name);
            //    root.AppendChild(element);
            //    for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
            //    {
            //        XmlElement childElement = doc.CreateElement("node");
            //        childElement.SetAttribute("text", treeView1.Nodes[i].Nodes[j].Text);
            //        childElement.SetAttribute("name", treeView1.Nodes[i].Nodes[j].Name);
            //        element.AppendChild(childElement);
            //    }
            //}

            //doc.Save("C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\XMLFiles\\TextTree.xml");

            //string filePath = "C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\Images\\Image1.png";

            //XmlDocument xmlDocument = new XmlDocument();

            //XmlElement rootElement = xmlDocument.CreateElement("image");
            //xmlDocument.AppendChild(rootElement);

            //XmlElement imageElement = xmlDocument.CreateElement("data");
            //imageElement.SetAttribute("type", "image/png");
            //imageElement.InnerText = File.ReadAllText(filePath);
            //rootElement.AppendChild(imageElement);

            //xmlDocument.Save("C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\XMLFiles\\Image.xml");



            XDocument doc = XDocument.Load("C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\XMLFiles\\Image.xml");
            var imageElement = doc.XPathSelectElement("//image/data");
            if (imageElement != null)
            {
                byte[] imageData = Convert.FromBase64String(imageElement.Value);
                using (var ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    var bitmap = (Bitmap)Image.FromStream(ms);
                    bitmap.Save("C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\Images\\NewImage.jpg");
                }
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            richTextBox1.Text = TakeText($"{e.Node.Name}.txt");
        }
        private string TakeText(string FileName)
        {
            string list;
            if (File.Exists($"C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\Texts\\{FileName}"))
            {
                using (StreamReader sr = new StreamReader($"C:\\Users\\Vostro\\source\\repos\\ProjEDU\\ProjEDU\\Texts\\{FileName}"))
                {
                    list = sr.ReadToEnd();
                }
                return list;
            }
            return "";
        }

       

        
    }
}
