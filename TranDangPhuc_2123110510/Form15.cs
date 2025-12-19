using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        // --- SỰ KIỆN 1: BẬT/TẮT Ô NHẬP GIẢM GIÁ ---
        private void CbDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDiscount.Checked == true)
            {
                tbDiscount.Enabled = true;  // Cho phép nhập
                tbDiscount.Focus();         // Đặt chuột vào đó luôn
            }
            else
            {
                tbDiscount.Enabled = false; // Khóa lại
                tbDiscount.Text = "0";      // Reset về 0
            }
        }

        // --- SỰ KIỆN 2: TÍNH TIỀN ---
        private void BtTinhTien_Click(object sender, EventArgs e)
        {
            string msg = "";

            // Xử lý xưng hô dựa trên RadioButton
            if (rbNam.Checked) msg = "Ông ";
            else msg = "Bà ";

            // Xử lý giảm giá
            int disc = 0;
            if (cbDiscount.Checked)
            {
                // Cố gắng lấy số từ ô nhập, nếu lỗi thì tính là 0
                int.TryParse(tbDiscount.Text, out disc);
            }

            // Hiển thị kết quả
            tbResult.Text = msg + tbName.Text + " được giảm " + disc + "%";
        }

        private void BtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}