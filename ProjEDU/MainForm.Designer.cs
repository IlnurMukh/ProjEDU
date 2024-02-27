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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            btnForward = new Button();
            richTextBox1 = new RichTextBox();
            menuStrip1.SuspendLayout();
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
            // testToolStripMenuItem
            // 
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(32, 19);
            // 
            // btnForward
            // 
            btnForward.BackgroundImage = (Image)resources.GetObject("btnForward.BackgroundImage");
            btnForward.BackgroundImageLayout = ImageLayout.Stretch;
            btnForward.Location = new Point(1125, 79);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(87, 63);
            btnForward.TabIndex = 2;
            btnForward.UseVisualStyleBackColor = true;
            btnForward.Click += btnForward_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(415, 139);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(353, 207);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(125, 24);
            editToolStripMenuItem.Text = "Редактировать";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 571);
            Controls.Add(richTextBox1);
            Controls.Add(btnForward);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private RichTextBox richTextBox1;
    }
}