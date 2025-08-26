using System;
using System.Windows.Forms;
using CSharp_learning.Services;
using CSharp_learning.Models;

namespace CSharp_learning.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseService _databaseService;
        private ListView listViewBooks;
        private Label lblTitle;

        public MainForm()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            LoadBooks();
        }

        private void InitializeComponent()
        {
            this.listViewBooks = new ListView();
            this.lblTitle = new Label();

            // Form
            this.Text = "图书管理系统 - 书籍列表";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            this.lblTitle = new Label();
            this.lblTitle.Text = "图书列表";
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(200, 30);

            // ListView
            this.listViewBooks.Location = new System.Drawing.Point(20, 60);
            this.listViewBooks.Size = new System.Drawing.Size(740, 480);
            this.listViewBooks.View = View.Details;
            this.listViewBooks.FullRowSelect = true;
            this.listViewBooks.GridLines = true;

            // Add columns
            this.listViewBooks.Columns.Add("ISBN", 120);
            this.listViewBooks.Columns.Add("书名", 200);
            this.listViewBooks.Columns.Add("作者", 120);
            this.listViewBooks.Columns.Add("出版社", 150);
            this.listViewBooks.Columns.Add("库存", 60);
            this.listViewBooks.Columns.Add("状态", 80);

            // Event handlers
            this.listViewBooks.DoubleClick += new EventHandler(listViewBooks_DoubleClick);

            // Add controls to form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.listViewBooks);
        }

        private void LoadBooks()
        {
            listViewBooks.Items.Clear();
            var books = _databaseService.GetAllBooks();

            foreach (var book in books)
            {
                var item = new ListViewItem(book.ISBN);
                item.SubItems.Add(book.Title);
                item.SubItems.Add(book.Author);
                item.SubItems.Add(book.Publisher);
                item.SubItems.Add(book.Quantity.ToString());
                item.SubItems.Add(book.IsAvailable ? "可借阅" : "已借出");
                item.Tag = book; // 存储整个书籍对象以便后续使用

                listViewBooks.Items.Add(item);
            }
        }

        private void listViewBooks_DoubleClick(object sender, EventArgs e)
        {
            if (listViewBooks.SelectedItems.Count > 0)
            {
                var book = (Book)listViewBooks.SelectedItems[0].Tag;
                var detailForm = new BookDetailForm(book);
                detailForm.ShowDialog();
            }
        }
    }
}
