using System;
using System.Windows.Forms;
using System.Drawing;

namespace CSharp_learning.DummyProject
{
    public class UserFormGUI : Form
    {
        private TextBox nameTextBox;
        private NumericUpDown ageNumericUpDown;
        private ListBox interestsListBox;
        private TextBox newInterestTextBox;
        private Button addInterestButton;

        public UserFormGUI()
        {
            InitializeComponents();
            LoadDefaultInterests();
        }

        private void InitializeComponents()
        {
            // 设置窗体属性
            Text = "用户信息表单";
            Size = new Size(400, 500);

            // 创建姓名输入区域
            var nameLabel = new Label
            {
                Text = "姓名:",
                Location = new Point(20, 20),
                Size = new Size(50, 20)
            };

            nameTextBox = new TextBox
            {
                Location = new Point(80, 20),
                Size = new Size(200, 20)
            };

            // 创建年龄输入区域
            var ageLabel = new Label
            {
                Text = "年龄:",
                Location = new Point(20, 50),
                Size = new Size(50, 20)
            };

            ageNumericUpDown = new NumericUpDown
            {
                Location = new Point(80, 50),
                Size = new Size(80, 20),
                Minimum = 1,
                Maximum = 120,
                Value = 25
            };

            // 创建兴趣爱好列表区域
            var interestsLabel = new Label
            {
                Text = "兴趣爱好:",
                Location = new Point(20, 90),
                Size = new Size(100, 20)
            };

            interestsListBox = new ListBox
            {
                Location = new Point(20, 120),
                Size = new Size(340, 200)
            };

            // 创建添加兴趣爱好的控件
            newInterestTextBox = new TextBox
            {
                Location = new Point(20, 340),
                Size = new Size(200, 20)
            };

            addInterestButton = new Button
            {
                Text = "添加兴趣爱好",
                Location = new Point(240, 338),
                Size = new Size(120, 25)
            };
            addInterestButton.Click += AddInterestButton_Click;

            // 将所有控件添加到窗体
            Controls.AddRange(new Control[] {
                nameLabel, nameTextBox,
                ageLabel, ageNumericUpDown,
                interestsLabel, interestsListBox,
                newInterestTextBox, addInterestButton
            });
        }

        private void LoadDefaultInterests()
        {
            string[] defaultInterests = new string[]
            {
                "阅读",
                "编程",
                "旅行",
                "摄影"
            };

            interestsListBox.Items.AddRange(defaultInterests);
        }

        private void AddInterestButton_Click(object sender, EventArgs e)
        {
            string newInterest = newInterestTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(newInterest))
            {
                interestsListBox.Items.Add(newInterest);
                newInterestTextBox.Clear();
                MessageBox.Show("已添加新的兴趣爱好: " + newInterest, "成功", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserFormGUI());
        }
    }
}
