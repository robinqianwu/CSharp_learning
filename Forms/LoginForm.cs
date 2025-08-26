using System;
using System.Windows.Forms;
using CSharp_learning.Services;

namespace CSharp_learning.Forms
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseService _databaseService;

        public LoginForm()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private void InitializeComponent()
        {
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            
            // Form
            this.Text = "图书管理系统 - 登录";
            this.Size = new System.Drawing.Size(300, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Username Label
            this.lblUsername.Text = "用户名:";
            this.lblUsername.Location = new System.Drawing.Point(20, 20);
            this.lblUsername.Size = new System.Drawing.Size(60, 20);
            
            // Username TextBox
            this.txtUsername.Location = new System.Drawing.Point(100, 20);
            this.txtUsername.Size = new System.Drawing.Size(150, 20);
            
            // Password Label
            this.lblPassword.Text = "密码:";
            this.lblPassword.Location = new System.Drawing.Point(20, 60);
            this.lblPassword.Size = new System.Drawing.Size(60, 20);
            
            // Password TextBox
            this.txtPassword.Location = new System.Drawing.Point(100, 60);
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.PasswordChar = '*';
            
            // Login Button
            this.btnLogin.Text = "登录";
            this.btnLogin.Location = new System.Drawing.Point(100, 100);
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.Click += new EventHandler(btnLogin_Click);
            
            // Add controls to form
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("请输入用户名和密码!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_databaseService.ValidateUser(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("登录成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: 打开主窗体
                // var mainForm = new MainForm();
                // mainForm.Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblUsername;
        private Label lblPassword;
    }
}
