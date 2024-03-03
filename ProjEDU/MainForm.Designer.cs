namespace ProjEDU
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            btnForward = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            richTextBox1 = new RichTextBox();
            treeView1 = new TreeView();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            imageList1 = new ImageList(components);
            richTextBox2 = new RichTextBox();
            treeView2 = new TreeView();
            richTextBox3 = new RichTextBox();
            treeView3 = new TreeView();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1296, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(67, 24);
            exitToolStripMenuItem.Text = "Выход";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(125, 24);
            editToolStripMenuItem.Text = "Редактировать";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(32, 19);
            // 
            // btnForward
            // 
            btnForward.BackgroundImage = (Image)resources.GetObject("btnForward.BackgroundImage");
            btnForward.BackgroundImageLayout = ImageLayout.Stretch;
            btnForward.Location = new Point(1197, 496);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(87, 63);
            btnForward.TabIndex = 2;
            btnForward.UseVisualStyleBackColor = true;
            btnForward.Click += btnForward_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1272, 459);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Controls.Add(treeView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1264, 426);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Текст";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(218, 6);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1040, 414);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "\n";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(6, 6);
            treeView1.Name = "treeView1";
            treeView1.RightToLeft = RightToLeft.No;
            treeView1.Size = new Size(206, 414);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // tabPage2
            // 
            tabPage2.AutoScroll = true;
            tabPage2.BackgroundImageLayout = ImageLayout.None;
            tabPage2.Controls.Add(richTextBox2);
            tabPage2.Controls.Add(treeView2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1264, 426);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Картинки";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(richTextBox3);
            tabPage3.Controls.Add(treeView3);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1264, 426);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Видео";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Image1.png");
            imageList1.Images.SetKeyName(1, "Без названия.png");
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(218, 6);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(1040, 414);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "\n";
            // 
            // treeView2
            // 
            treeView2.Location = new Point(6, 6);
            treeView2.Name = "treeView2";
            treeView2.RightToLeft = RightToLeft.No;
            treeView2.Size = new Size(206, 414);
            treeView2.TabIndex = 2;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(218, 6);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(1040, 414);
            richTextBox3.TabIndex = 3;
            richTextBox3.Text = "\n";
            // 
            // treeView3
            // 
            treeView3.Location = new Point(6, 6);
            treeView3.Name = "treeView3";
            treeView3.RightToLeft = RightToLeft.No;
            treeView3.Size = new Size(206, 414);
            treeView3.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 571);
            Controls.Add(btnForward);
            Controls.Add(menuStrip1);
            Controls.Add(tabControl1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            RightToLeft = RightToLeft.No;
            Text = "MainForm";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;

        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private Panel pnlTheoryTest;
        private Button btnTheory;
        private Button btnTest;
        private Button btnForward;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TreeView treeView1;
        private RichTextBox richTextBox1;
        private ImageList imageList1;
        private RichTextBox richTextBox2;
        private TreeView treeView2;
        private RichTextBox richTextBox3;
        private TreeView treeView3;
    }
}