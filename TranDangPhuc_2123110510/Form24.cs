using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form24 : Form
    {
        // Khai báo biến toạ độ x, y để quản lý vị trí ảnh
        // Giá trị ban đầu phải khớp với Location(50, 50) trong Designer
        private int x = 50;
        private int y = 50;

        public Form24()
        {
            InitializeComponent();

            // Đồng bộ hoá biến x, y với vị trí thực tế của ảnh (để chắc chắn)
            x = pbImage.Location.X;
            y = pbImage.Location.Y;
        }

        // --- CHỨC NĂNG 1: CHỌN ẢNH ---
        private void BtFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = dlg.FileName;
            }
        }

        // --- CHỨC NĂNG 2: DI CHUYỂN TRÁI ---
        private void BtLeft_Click(object sender, EventArgs e)
        {
            x -= 10; // Giảm toạ độ x để sang trái
            pbImage.Location = new Point(x, y);
        }

        // --- CHỨC NĂNG 3: DI CHUYỂN PHẢI ---
        private void BtRight_Click(object sender, EventArgs e)
        {
            x += 10; // Tăng toạ độ x để sang phải
            pbImage.Location = new Point(x, y);
        }
    }
}