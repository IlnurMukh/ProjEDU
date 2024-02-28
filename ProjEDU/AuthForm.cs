using System.Data.Entity.Infrastructure.Interception;
using ProjEDU.Model;

namespace ProjEDU
{
    public partial class AuthForm : Form
    {
        private bool _newAcc = true;
        private bool _successful = false;
        private bool _isTeacher = false;
        public AuthForm()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '\u25CF';
            tbConfirmPassword.PasswordChar = '\u25CF';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnRegister.Enabled = true;
            lblConfirmPassword.Visible = false;
            lblConfirmPassword.Enabled = false;
            tbConfirmPassword.Visible = false;
            tbConfirmPassword.Enabled = false;
            tbConfirmPassword.Clear();
            _newAcc = false;
            btnEnter.Text = "Войти";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;
            btnLogin.Enabled = true;
            lblConfirmPassword.Visible = true;
            lblConfirmPassword.Enabled = true;
            tbConfirmPassword.Visible = true;
            tbConfirmPassword.Enabled = true;
            _newAcc = true;
            btnEnter.Text = "Зарегистрироваться";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!_newAcc)
            {
                using (UserContext dbContext = new UserContext())
                {
                    List<User> dbUsers = dbContext.Users.ToList();
                    List<User> foundedUsers =
                        dbUsers.Where(u => u.Login == tbLogin.Text && u.Password == tbPassword.Text).ToList();
                    if (foundedUsers.Count > 0)
                    {
                        if (foundedUsers[0].Teacher)
                            _isTeacher = true;
                        _successful = true;
                    }
                    else
                    {
                        MessageBox.Show("Неверные логин или пароль", "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            if (_newAcc && tbPassword.Text == tbConfirmPassword.Text)
            {
                if (tbLogin.Text.Length < 6)
                {
                    MessageBox.Show("Некорректная длина логина", "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //TODO Проверить логин
                }
                else
                {
                    using (UserContext dbContext = new UserContext())
                    {
                        List<User> dbUsers = dbContext.Users.ToList();
                        if (dbUsers.All(u => u.Login != tbLogin.Text))
                        {
                            dbContext.Users.Add(new User() { Login = tbLogin.Text, Password = tbPassword.Text });
                            dbContext.SaveChanges();
                            _successful = true;
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            tbLogin.Text = "";
                            tbPassword.Text = "";
                            tbConfirmPassword.Text = "";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tbPassword.Text = "";
                tbConfirmPassword.Text = "";
            }

            if (_successful)
            {
                MainForm mainForm = new MainForm(tbLogin.Text, _isTeacher);
                mainForm.Closed += (_, _) => this.Close();
                this.Visible = false;
                if (mainForm.ShowDialog() == DialogResult.OK)
                {
                    tbLogin.Text = "";
                    tbPassword.Text = "";
                    tbConfirmPassword.Text = "";
                    Visible = true;
                }
            }
        }
    }
}
