using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form17 : Form
    {
        // Biến đếm số thứ tự sinh viên (1, 2, 3...)
        private int stt = 0;

        public Form17()
        {
            InitializeComponent();
            cbFaculty.SelectedIndex = 0; // Chọn mặc định khoa đầu tiên
        }

        // --- SỰ KIỆN: BẤM NÚT THÊM ---
        private void BtThem_Click(object sender, EventArgs e)
        {
            // Tăng số thứ tự
            stt++;

            // Lấy thông tin từ các Control
            string ten = tbName.Text;
            string ngaySinh = dtpDob.Value.ToShortDateString();
            string gioiTinh = rbNam.Checked ? "Nam" : "Nữ"; // Nếu rbNam chọn thì là Nam, ngược lại là Nữ
            string khoa = cbFaculty.SelectedItem.ToString();

            // Thêm từng dòng vào ListBox để hiển thị
            lbTrangThai.Items.Add(stt + ". " + ten);
            lbTrangThai.Items.Add("    -Giới tính: " + gioiTinh);
            lbTrangThai.Items.Add("    -Ngày Sinh: " + ngaySinh);
            lbTrangThai.Items.Add("    -Khoa: " + khoa);

            // (Tùy chọn) Thêm dòng trống để ngăn cách cho đẹp
            lbTrangThai.Items.Add("");
        }

        private void BtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}