using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        // --- SỰ KIỆN CHỌN ẢNH (Logic Slide 129) ---
        private void BtFile_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại mở file
            OpenFileDialog dlg = new OpenFileDialog();

            // Chỉ lọc file ảnh jpg, png
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            dlg.Title = "Open Image";

            // Nếu người dùng chọn file và bấm OK
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Cách 1: Dùng ImageLocation (Đường dẫn file) - Nhẹ, không khóa file gốc
                pbImage.ImageLocation = dlg.FileName;
            }
        }
    }
}