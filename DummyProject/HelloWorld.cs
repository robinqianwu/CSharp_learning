using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using NameGenerator;

namespace CSharp_learning.DummyProject
{
    public class UserFormGUI : Form
    {
        private TextBox? nameTextBox;
        private NumericUpDown? ageNumericUpDown;
        private ListBox? interestsListBox;
        private TextBox? newInterestTextBox;
        private Button? addInterestButton;

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
                Size = new Size(200, 20),
                PlaceholderText = "Chali"
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
            newInterestTextBox.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true; // 防止发出蜂鸣声
                    if (addInterestButton != null)
                    {
                        AddInterestButton_Click(addInterestButton, EventArgs.Empty);
                    }
                }
            };

            addInterestButton = new Button
            {
                Text = "添加兴趣爱好",
                Location = new Point(240, 338),
                Size = new Size(120, 25)
            };
            addInterestButton.Click += AddInterestButton_Click;

            // 将所有控件添加到窗体
            // 创建随机英文名字生成按钮
            var generateNameButton = new Button
            {
                Text = "生成随机英文名字",
                Location = new Point(20, 380),
                Size = new Size(340, 25)
            };
            generateNameButton.Click += (s, e) =>
            {
                string randomName = NameGenerator.EnglishNameGenerator.GenerateRandomName();
                nameTextBox.Text = randomName;
                MessageBox.Show($"已生成随机英文名字: {randomName}", "名字生成成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            Controls.AddRange(new Control[] {
                nameLabel, nameTextBox,
                ageLabel, ageNumericUpDown,
                interestsLabel, interestsListBox,
                newInterestTextBox, addInterestButton,
                generateNameButton
            });

            // 设置初始焦点到兴趣输入框
            this.ActiveControl = newInterestTextBox;
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

            if (interestsListBox != null)
            {
                interestsListBox.Items.AddRange(defaultInterests);
            }
        }

        private void AddInterestButton_Click(object? sender, EventArgs e)
        {
            if (newInterestTextBox != null)
            {
                string newInterest = newInterestTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(newInterest) && interestsListBox != null)
                {
                    interestsListBox.Items.Add(newInterest);
                    newInterestTextBox.Clear();
                    MessageBox.Show("已添加新的兴趣爱好: " + newInterest, "成功添加， 现在有 " + interestsListBox.Items.Count + " 个兴趣爱好",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 不同类型的日志输出
                    var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    Console.WriteLine($"[{timestamp}] Console: 添加了新兴趣 {newInterest}"); // 控制台输出
                    Debug.WriteLine($"[{timestamp}] Debug: 添加了新兴趣 {newInterest}"); // Debug输出
                    Trace.WriteLine($"[{timestamp}] Trace: 添加了新兴趣 {newInterest}"); // Trace输出
                }
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            // 设置Trace输出到文件（Debug输出也会进入这个监听器）
            TextWriterTraceListener traceListener = new TextWriterTraceListener("debug_trace.log");
            Trace.Listeners.Add(traceListener);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try 
            {
                Application.Run(new UserFormGUI());
            }
            finally
            {
                // 确保所有日志都被写入文件
                Trace.Flush();
                traceListener.Close();
            }
        }
    }
}
