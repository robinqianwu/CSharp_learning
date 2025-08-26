using System;
using System.Windows.Forms;
using CSharp_learning.Models;

namespace CSharp_learning.Forms
{
    public partial class BookDetailForm : Form
    {
        private readonly Book _book;

        public BookDetailForm(Book book)
        {
            _book = book;
            InitializeComponent();
            LoadBookDetails();
        }

        private void InitializeComponent()
        {
            this.Text = "图书详情";
            this.Size = new System.Drawing.Size(400, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                RowCount = 8,
                ColumnCount = 2
            };

            // 添加标签和内容
            AddLabelAndContent(layout, 0, "ISBN:");
            AddLabelAndContent(layout, 1, "书名:");
            AddLabelAndContent(layout, 2, "作者:");
            AddLabelAndContent(layout, 3, "出版社:");
            AddLabelAndContent(layout, 4, "出版日期:");
            AddLabelAndContent(layout, 5, "库存数量:");
            AddLabelAndContent(layout, 6, "状态:");

            Button closeButton = new Button
            {
                Text = "关闭",
                Dock = DockStyle.Bottom,
                Height = 30
            };
            closeButton.Click += (s, e) => this.Close();

            layout.Controls.Add(closeButton);
            layout.SetColumnSpan(closeButton, 2);

            this.Controls.Add(layout);
        }

        private void AddLabelAndContent(TableLayoutPanel layout, int row, string labelText)
        {
            Label label = new Label
            {
                Text = labelText,
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 5)
            };

            Label content = new Label
            {
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 5)
            };

            layout.Controls.Add(label, 0, row);
            layout.Controls.Add(content, 1, row);
        }

        private void LoadBookDetails()
        {
            var layout = (TableLayoutPanel)this.Controls[0];
            
            // 设置各个标签的内容
            ((Label)layout.GetControlFromPosition(1, 0)).Text = _book.ISBN;
            ((Label)layout.GetControlFromPosition(1, 1)).Text = _book.Title;
            ((Label)layout.GetControlFromPosition(1, 2)).Text = _book.Author;
            ((Label)layout.GetControlFromPosition(1, 3)).Text = _book.Publisher;
            ((Label)layout.GetControlFromPosition(1, 4)).Text = _book.PublishDate.ToShortDateString();
            ((Label)layout.GetControlFromPosition(1, 5)).Text = _book.Quantity.ToString();
            ((Label)layout.GetControlFromPosition(1, 6)).Text = _book.IsAvailable ? "可借阅" : "已借出";
        }
    }
}
