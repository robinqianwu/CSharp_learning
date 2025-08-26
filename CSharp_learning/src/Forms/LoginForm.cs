using System;
using System.Windows.Forms;

namespace CSharp_learning.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // 这里可以调用身份验证服务来验证用户凭据
            var authService = new AuthenticationService();
            if (authService.Login(username, password))
            {
                // 登录成功，打开主界面
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误，请重试。", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}