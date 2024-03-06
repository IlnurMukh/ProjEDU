namespace ProjEDU
{
    partial class AddContentForm
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
            btnCancel = new Button();
            btnOK = new Button();
            lblTitle = new Label();
            lblURL = new Label();
            tbTitle = new TextBox();
            tbURL = new TextBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(44, 118);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(194, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Отменить";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(296, 118);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(194, 29);
            btnOK.TabIndex = 1;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(135, 20);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Введите название";
            // 
            // lblURL
            // 
            lblURL.AutoSize = true;
            lblURL.Location = new Point(12, 62);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(120, 20);
            lblURL.TabIndex = 3;
            lblURL.Text = "Вставьте ссылку";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(15, 32);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(512, 27);
            tbTitle.TabIndex = 4;
            // 
            // tbURL
            // 
            tbURL.Location = new Point(12, 85);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(515, 27);
            tbURL.TabIndex = 5;
            // 
            // AddContentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 163);
            Controls.Add(tbURL);
            Controls.Add(tbTitle);
            Controls.Add(lblURL);
            Controls.Add(lblTitle);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Name = "AddContentForm";
            Text = "AddContentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnOK;
        private Label lblTitle;
        private Label lblURL;
        private TextBox tbTitle;
        private TextBox tbURL;
    }
}