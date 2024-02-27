namespace ProjEDU
{
    partial class AuthForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbLogin = new TextBox();
            tbPassword = new TextBox();
            lblMain = new Label();
            lblLogin = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            lblConfirmPassword = new Label();
            tbConfirmPassword = new TextBox();
            btnEnter = new Button();
            SuspendLayout();
            // 
            // tbLogin
            // 
            tbLogin.Location = new Point(97, 202);
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(268, 27);
            tbLogin.TabIndex = 0;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(98, 281);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(268, 27);
            tbPassword.TabIndex = 1;
            // 
            // lblMain
            // 
            lblMain.AutoSize = true;
            lblMain.Font = new Font("Segoe UI", 24F);
            lblMain.Location = new Point(148, 9);
            lblMain.Name = "lblMain";
            lblMain.Size = new Size(167, 54);
            lblMain.TabIndex = 2;
            lblMain.Text = "ProjEDU";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 18F);
            lblLogin.Location = new Point(179, 158);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(101, 41);
            lblLogin.TabIndex = 3;
            lblLogin.Text = "Логин";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 18F);
            lblPassword.Location = new Point(169, 237);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(121, 41);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Font = new Font("Segoe UI", 16F);
            btnLogin.Location = new Point(39, 95);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(182, 43);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Вход";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Enabled = false;
            btnRegister.Font = new Font("Segoe UI", 16F);
            btnRegister.Location = new Point(227, 95);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(195, 43);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Регистрация";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 18F);
            lblConfirmPassword.Location = new Point(97, 324);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(273, 41);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Повторите пароль";
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.Location = new Point(98, 368);
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.Size = new Size(268, 27);
            tbConfirmPassword.TabIndex = 7;
            // 
            // btnEnter
            // 
            btnEnter.AutoSize = true;
            btnEnter.Font = new Font("Segoe UI", 14F);
            btnEnter.Location = new Point(110, 424);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(246, 55);
            btnEnter.TabIndex = 9;
            btnEnter.Text = "Зарегистрироваться";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 507);
            Controls.Add(btnEnter);
            Controls.Add(lblConfirmPassword);
            Controls.Add(tbConfirmPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(lblLogin);
            Controls.Add(lblMain);
            Controls.Add(tbPassword);
            Controls.Add(tbLogin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbLogin;
        private TextBox tbPassword;
        private Label lblMain;
        private Label lblLogin;
        private Label lblPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Label lblConfirmPassword;
        private TextBox tbConfirmPassword;
        private Button btnEnter;
    }
}
