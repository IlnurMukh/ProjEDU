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
        private Panel currentPanel;
        private int currentQuestionType = 0;
        XmlElement currentQuestion;
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

            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Test");
                doc = Content.ToXml(contentFirst.XMLText);
            }
            foreach (XmlNode node in doc.SelectNodes("//question"))
            {
                var treeNode = new TreeNode();
                treeNode.Text = $"{node.Attributes["id"].Value} вопрос";
                treeNode.Name = node.Attributes["id"].Value;
                treeView4.Nodes.Add(treeNode);
            }
            XmlElement test = doc.DocumentElement;
            if (test != null)
            {
                panelList = new Panel[doc.SelectNodes("//question").Count + 1];

                foreach (XmlElement question in test)
                {
                    LoadTestPanel(question);
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
            using (ContentContext contentContext = new ContentContext())
            {
                List<Content> contents = contentContext.Contents.ToList();
                Content contentFirst = contents.First(c => c.Type == "Test");
                doc = Content.ToXml(contentFirst.XMLText);
            }
            XmlElement test = doc.DocumentElement;
            if (test != null)
            {

                foreach (XmlElement question in test)
                {
                    if (question.Attributes["id"].Value == e.Node.Name)
                    {
                        currentQuestion = question;
                        currentQuestionType = int.Parse(question.Attributes["type"].Value);
                        SwitchPanels(panelList[int.Parse(e.Node.Name)]);
                    }
                }
            }
        }

        private void LoadTestPanel(XmlElement question)
        {
            if (treeView4.Nodes.ContainsKey(question.Attributes["id"].Value))
            {
                int id = int.Parse(question.Attributes["id"].Value);
                Panel panelTest = new Panel();
                tabPage4.Controls.Add(panelTest);
                panelTest.Location = new Point(215, 3);
                panelTest.Size = new Size(1046, 379);
                panelTest.Name = question.Attributes["id"].Value;
                panelTest.Visible = false;
                panelList[id] = panelTest;
                Label lblQestion = new Label();
                lblQestion.Location = new Point(17, 17);
                lblQestion.Text = question.Attributes["qtext"].Value;
                lblQestion.AutoSize = true;
                panelTest.Controls.Add(lblQestion);

                switch (question.Attributes["type"].Value)
                {
                    case "1":

                        {
                            LoadPanelType1(panelTest, question);
                        }
                        break;
                    case "2":
                        {
                            LoadPanelType2(panelTest, question);
                        }
                        break;
                    case "3":
                        {
                            LoadPanelType3(panelTest, question);
                        }
                        break;
                    case "4":
                        {
                            LoadPanelType4(panelTest, question);
                        }
                        break;

                }
            }
        }

        private void SwitchPanels(Panel foundPanel)
        {
            foreach (var panel in panelList)
            {
                if (panel != null)
                {
                    if (foundPanel != panel)
                    {
                        panel.Visible = false;
                        panel.Enabled = false;
                    }
                    else
                    {
                        panel.Visible = true;
                        panel.Enabled = true;
                        currentPanel = panel;
                    }
                }
            }
        }

        private void LoadPanelType1(Panel panelTest, XmlElement question)
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
            foreach (XmlNode childnode in question.ChildNodes)
            {
                if (childnode.Name == "ansvar")
                {
                    foreach (var control in tableLayoutPanel1.Controls)
                    {
                        if (control is RadioButton rButton && rButton.Name == childnode.Attributes["id"].Value)
                        {
                            rButton.Text = childnode.Attributes["text"].Value;
                        }
                    }
                }
            }
        }
        private void LoadPanelType2(Panel panelTest, XmlElement question)
        {
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            panelTest.Controls.Add(tableLayoutPanel1);
            CheckBox checkBox1 = new CheckBox();
            CheckBox checkBox2 = new CheckBox();
            CheckBox checkBox3 = new CheckBox();
            CheckBox checkBox4 = new CheckBox();
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 3);
            checkBox1.Size = new Size(117, 24);
            checkBox1.TabIndex = 1;
            checkBox1.TabStop = true;
            checkBox1.Text = "CheckBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(3, 96);
            checkBox4.Size = new Size(117, 24);
            checkBox4.TabIndex = 4;
            checkBox4.TabStop = true;
            checkBox4.Text = "CheckBox4";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(3, 34);
            checkBox2.Size = new Size(117, 24);
            checkBox2.TabIndex = 2;
            checkBox2.TabStop = true;
            checkBox2.Text = "CheckBox2";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(3, 65);
            checkBox3.Size = new Size(117, 24);
            checkBox3.TabIndex = 3;
            checkBox3.TabStop = true;
            checkBox3.Text = "CheckBox3";
            checkBox3.UseVisualStyleBackColor = true;

            checkBox1.Name = "1";
            checkBox2.Name = "2";
            checkBox3.Name = "3";
            checkBox4.Name = "4";
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(checkBox3, 0, 2);
            tableLayoutPanel1.Controls.Add(checkBox4, 0, 3);
            tableLayoutPanel1.Location = new Point(17, 73);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(250, 125);
            tableLayoutPanel1.TabIndex = 6;
            foreach (XmlNode childnode in question.ChildNodes)
            {
                if (childnode.Name == "ansvar")
                {
                    foreach (var control in tableLayoutPanel1.Controls)
                    {
                        if (control is CheckBox cbButton && cbButton.Name == childnode.Attributes["id"].Value)
                        {
                            cbButton.Text = childnode.Attributes["text"].Value;
                        }
                    }
                }
            }
        }
        private void LoadPanelType3(Panel panelTest, XmlElement question)
        {
            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(17, 100);
            textBox1.Size = new Size(200, 27);
            textBox1.TabIndex = 4;
            panelTest.Controls.Add(textBox1);
        }
        private void LoadPanelType4(Panel panelTest, XmlElement question)
        {
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            Label label5 = new Label();
            Label label6 = new Label();
            Label label7 = new Label();
            Label label8 = new Label();
            NumericUpDown numericUpDown1 = new NumericUpDown();
            numericUpDown1.Name = "1";
            NumericUpDown numericUpDown2 = new NumericUpDown();
            numericUpDown2.Name = "2";
            NumericUpDown numericUpDown3 = new NumericUpDown();
            numericUpDown3.Name = "3";
            NumericUpDown numericUpDown4 = new NumericUpDown();
            numericUpDown4.Name = "4";
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 55);
            label2.Name = "2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 110);
            label3.Name = "3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 165);
            label4.Name = "4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 3;
            label4.Text = "label4";


            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(244, 0);
            label5.Name = "1";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 8;
            label5.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(244, 55);
            label6.Name = "2";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 5;
            label6.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(244, 110);
            label7.Name = "3";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 7;
            label7.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(244, 165);
            label8.Name = "4";
            label8.Size = new Size(50, 20);
            label8.TabIndex = 6;
            label8.Text = "";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(204, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "1";
            numericUpDown1.Size = new Size(34, 27);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(204, 58);
            numericUpDown2.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "2";
            numericUpDown2.Size = new Size(34, 27);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(204, 113);
            numericUpDown3.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "3";
            numericUpDown3.Size = new Size(34, 27);
            numericUpDown3.TabIndex = 11;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(204, 168);
            numericUpDown4.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown4.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown4.Name = "4";
            numericUpDown4.Size = new Size(34, 27);
            numericUpDown4.TabIndex = 12;
            numericUpDown4.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tableLayoutPanel1
            // 

            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            panelTest.Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label8, 2, 3);
            tableLayoutPanel1.Controls.Add(label7, 2, 2);
            tableLayoutPanel1.Controls.Add(label6, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 2, 0);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 1, 0);
            tableLayoutPanel1.Controls.Add(numericUpDown2, 1, 1);
            tableLayoutPanel1.Controls.Add(numericUpDown3, 1, 2);
            tableLayoutPanel1.Controls.Add(numericUpDown4, 1, 3);
            tableLayoutPanel1.Location = new Point(21, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(443, 221);
            tableLayoutPanel1.TabIndex = 4;

            foreach (XmlNode childnode in question.ChildNodes)
            {
                if (childnode.Name == "ansvar1")
                {
                    foreach (var control in tableLayoutPanel1.Controls)
                    {
                        if (control is Label lbl && lbl.Name == childnode.Attributes["id"].Value && tableLayoutPanel1.GetColumn(lbl) == 0)
                        {
                            lbl.Text = $"{childnode.Attributes["id"].Value}. {childnode.Attributes["text"].Value}";
                        }
                    }
                }
                if (childnode.Name == "ansvar2")
                {
                    foreach (var control in tableLayoutPanel1.Controls)
                    {
                        if (control is Label lbl && lbl.Name == childnode.Attributes["id"].Value && tableLayoutPanel1.GetColumn(lbl) == 2)
                        {
                            lbl.Text = childnode.Attributes["text"].Value;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (currentQuestionType)
            {
                case 1:
                {
                    foreach (Control control in currentPanel.Controls)
                    {
                        if (control is TableLayoutPanel tableLayoutPanel)
                        {
                            XmlElement correctAnswer = null;
                            foreach (XmlElement child in currentQuestion)
                            {
                                if(child.Name == "correctanswer")
                                    correctAnswer = child;
                            }
                            foreach (Control tlpControl in tableLayoutPanel.Controls)
                            {
                                if (tlpControl is RadioButton { Checked: true } rButton)
                                {
                                    if (rButton.Name == correctAnswer.Attributes["id"].Value)
                                    {
                                        //TODO Dop-dores, malades
                                        MessageBox.Show("good");
                                    }
                                    else
                                    {
                                            // TODO Dores tugel, ebantяy
                                            MessageBox.Show("bad");
                                    }
                                }
                            }
                        }
                    }
                }break;
                case 2:
                {
                    foreach (Control control in currentPanel.Controls)
                    {
                        if (control is TableLayoutPanel tableLayoutPanel)
                        {
                            int correctAnswersCount = 0;
                            bool correctAnswer = true;
                            Dictionary<string, bool> answers = new Dictionary<string, bool>();
                            foreach (XmlElement child in currentQuestion)
                            {
                                if (child.Name == "ansvar")
                                    answers.Add(child.Attributes["id"].Value, false);
                                if (child.Name == "correctanswer")
                                    answers[child.Attributes["id"].Value] = true;
                            }
                            foreach (Control tlpControl in tableLayoutPanel.Controls)
                            {
                                if (tlpControl is CheckBox {Checked: true} checkBox)
                                {
                                    if (answers[checkBox.Name] == false)
                                        correctAnswer = false;
                                }
                            }
                            if (correctAnswer)
                            {
                                //TODO Dop-dores, malades
                                MessageBox.Show("good");
                            }
                            else
                            {
                                // TODO Dores tugel, ebantяy
                                MessageBox.Show("bad");
                            }
                        }
                    }
                }
                    break;
                case 3:
                {
                    foreach (Control control in currentPanel.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            if (textBox.Text == currentQuestion.Attributes["correctanswer"].Value)
                            {
                                //TODO Dop-dores, malades
                                MessageBox.Show("good");
                            }
                            else
                            {
                                // TODO Dores tugel, ebantяy
                                MessageBox.Show("bad");
                            }
                        }
                    }
                }
                    break;
                case 4:
                {
                    foreach (Control control in currentPanel.Controls)
                    {
                        if (control is TableLayoutPanel tableLayoutPanel)
                        {
                            string[] correctAnswers = new string[4];
                            foreach (XmlElement child in currentQuestion)
                            {
                                if (child.Name == "correctanswerpair")
                                    correctAnswers[int.Parse(child.Attributes["id1"].Value) - 1] =
                                        child.Attributes["id2"].Value;

                            }
                            string[] answers = new string[4];
                            foreach (Control tlpControl in tableLayoutPanel.Controls)
                            {
                                if (tlpControl is NumericUpDown numeric)
                                {
                                    answers[int.Parse(numeric.Name) - 1] = numeric.Text;
                                }
                            }

                            bool equal = true;
                            for (int i = 0; i < 4; i++)
                            {
                                if (answers[i] != correctAnswers[i]) 
                                    equal = false;
                            }

                            if (equal)
                            {
                                //TODO Dop-dores, malades
                                MessageBox.Show("good");
                            }
                            else
                            {
                                // TODO Dores tugel, ebantяy
                                MessageBox.Show("bad");
                            }
                        }
                    }
                }
                    break;
            }
        }
    }

}
