namespace ProjEDU
{
    partial class EditForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnSave1 = new Button();
            btnAddChild1 = new Button();
            btnDel1 = new Button();
            btnAddNode1 = new Button();
            richTextBox1 = new RichTextBox();
            treeView1 = new TreeView();
            tabPage2 = new TabPage();
            btnEdit2 = new Button();
            btnDel2 = new Button();
            btnAdd2 = new Button();
            richTextBox2 = new RichTextBox();
            treeView2 = new TreeView();
            tabPage3 = new TabPage();
            btnEdit3 = new Button();
            btnDel3 = new Button();
            btnAdd3 = new Button();
            richTextBox3 = new RichTextBox();
            treeView3 = new TreeView();
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            tabPage4 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(3, 33);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1272, 459);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnSave1);
            tabPage1.Controls.Add(btnAddChild1);
            tabPage1.Controls.Add(btnDel1);
            tabPage1.Controls.Add(btnAddNode1);
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
            // btnSave1
            // 
            btnSave1.Location = new Point(117, 355);
            btnSave1.Name = "btnSave1";
            btnSave1.Size = new Size(95, 62);
            btnSave1.TabIndex = 5;
            btnSave1.Text = "Сохранить";
            btnSave1.UseVisualStyleBackColor = true;
            btnSave1.Click += btnSave1_Click;
            // 
            // btnAddChild1
            // 
            btnAddChild1.Location = new Point(6, 355);
            btnAddChild1.Name = "btnAddChild1";
            btnAddChild1.Size = new Size(95, 62);
            btnAddChild1.TabIndex = 4;
            btnAddChild1.Text = "Добавить подтему";
            btnAddChild1.UseVisualStyleBackColor = true;
            btnAddChild1.Click += btnAddChild1_Click;
            // 
            // btnDel1
            // 
            btnDel1.Location = new Point(117, 287);
            btnDel1.Name = "btnDel1";
            btnDel1.Size = new Size(95, 62);
            btnDel1.TabIndex = 3;
            btnDel1.Text = "Удалить";
            btnDel1.UseVisualStyleBackColor = true;
            btnDel1.Click += btnDel1_Click;
            // 
            // btnAddNode1
            // 
            btnAddNode1.Location = new Point(6, 287);
            btnAddNode1.Name = "btnAddNode1";
            btnAddNode1.Size = new Size(95, 62);
            btnAddNode1.TabIndex = 2;
            btnAddNode1.Text = "Добавить тему";
            btnAddNode1.UseVisualStyleBackColor = true;
            btnAddNode1.Click += btnAddNode1_Click;
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
            treeView1.Size = new Size(206, 275);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // tabPage2
            // 
            tabPage2.AutoScroll = true;
            tabPage2.BackgroundImageLayout = ImageLayout.None;
            tabPage2.Controls.Add(btnEdit2);
            tabPage2.Controls.Add(btnDel2);
            tabPage2.Controls.Add(btnAdd2);
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
            // btnEdit2
            // 
            btnEdit2.Location = new Point(6, 355);
            btnEdit2.Name = "btnEdit2";
            btnEdit2.Size = new Size(95, 62);
            btnEdit2.TabIndex = 6;
            btnEdit2.Text = "Изменить";
            btnEdit2.UseVisualStyleBackColor = true;
            btnEdit2.Click += btnEdit2_Click;
            // 
            // btnDel2
            // 
            btnDel2.Location = new Point(117, 355);
            btnDel2.Name = "btnDel2";
            btnDel2.Size = new Size(95, 62);
            btnDel2.TabIndex = 5;
            btnDel2.Text = "Удалить";
            btnDel2.UseVisualStyleBackColor = true;
            btnDel2.Click += btnDel2_Click;
            // 
            // btnAdd2
            // 
            btnAdd2.Location = new Point(6, 287);
            btnAdd2.Name = "btnAdd2";
            btnAdd2.Size = new Size(206, 62);
            btnAdd2.TabIndex = 4;
            btnAdd2.Text = "Добавить";
            btnAdd2.UseVisualStyleBackColor = true;
            btnAdd2.Click += btnAdd2_Click;
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
            treeView2.Size = new Size(206, 275);
            treeView2.TabIndex = 2;
            treeView2.AfterSelect += treeView2_AfterSelect;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnEdit3);
            tabPage3.Controls.Add(btnDel3);
            tabPage3.Controls.Add(btnAdd3);
            tabPage3.Controls.Add(richTextBox3);
            tabPage3.Controls.Add(treeView3);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1264, 426);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Видео";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEdit3
            // 
            btnEdit3.Location = new Point(6, 355);
            btnEdit3.Name = "btnEdit3";
            btnEdit3.Size = new Size(95, 62);
            btnEdit3.TabIndex = 6;
            btnEdit3.Text = "Изменить";
            btnEdit3.UseVisualStyleBackColor = true;
            btnEdit3.Click += btnEdit3_Click;
            // 
            // btnDel3
            // 
            btnDel3.Location = new Point(117, 355);
            btnDel3.Name = "btnDel3";
            btnDel3.Size = new Size(95, 62);
            btnDel3.TabIndex = 5;
            btnDel3.Text = "Удалить";
            btnDel3.UseVisualStyleBackColor = true;
            btnDel3.Click += btnDel3_Click;
            // 
            // btnAdd3
            // 
            btnAdd3.Location = new Point(6, 287);
            btnAdd3.Name = "btnAdd3";
            btnAdd3.Size = new Size(206, 62);
            btnAdd3.TabIndex = 4;
            btnAdd3.Text = "Добавить";
            btnAdd3.UseVisualStyleBackColor = true;
            btnAdd3.Click += btnAdd3_Click;
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
            treeView3.Size = new Size(206, 275);
            treeView3.TabIndex = 2;
            treeView3.AfterSelect += treeView3_AfterSelect;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1278, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(67, 24);
            exitToolStripMenuItem.Text = "Выход";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(97, 24);
            editToolStripMenuItem.Text = "Сохранить";
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1264, 426);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Тест";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 524);
            Controls.Add(menuStrip1);
            Controls.Add(tabControl1);
            Name = "EditForm";
            Text = "EditForm";
            Load += EditForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private RichTextBox richTextBox1;
        private TreeView treeView1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private RichTextBox richTextBox2;
        private TreeView treeView2;
        private RichTextBox richTextBox3;
        private TreeView treeView3;
        private Button btnDel1;
        private Button btnAddNode1;
        private Button btnDel2;
        private Button btnAdd2;
        private Button btnDel3;
        private Button btnAdd3;
        private Button btnSave1;
        private Button btnAddChild1;
        private Button btnEdit2;
        private Button btnEdit3;
        private TabPage tabPage4;
    }
}