using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        // --- SỰ KIỆN 1: KHI FORM VỪA CHẠY ---
        private void Form13_Load(object sender, EventArgs e)
        {
            // Tự động chọn dòng thứ 3 (Index = 2) là "Quản trị kinh doanh"
            if (cbFaculty.Items.Count >= 3)
            {
                cbFaculty.SelectedIndex = 2;
            }
        }

        // --- SỰ KIỆN 2: KHI NGƯỜI DÙNG CHỌN MỤC KHÁC ---
        private void Cb_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbFaculty.SelectedIndex;
            int thuTuNguoiDung = index + 1;
            tbDisplay.Text = "Bạn đã chọn khoa thứ: " + thuTuNguoiDung.ToString();
        }

        // --- SỰ KIỆN 3: KHI BẤM NÚT OK ---
        private void BtOK_Click(object sender, EventArgs e)
        {
            if (cbFaculty.SelectedItem != null)
            {
                // Lấy nội dung chữ của mục đang chọn
                string item = cbFaculty.SelectedItem.ToString();
                tbDisplay.Text = "Bạn là sinh viên khoa : " + item;
            }
        }

        // --- SỰ KIỆN 4: KHI BẤM NÚT CLEAR ---
        private void BtClear_Click(object sender, EventArgs e)
        {
            tbDisplay.Clear();
        }
    }
}