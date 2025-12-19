using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        // --- HÀM TẠO DỮ LIỆU GIẢ ---
        public ArrayList GetData()
        {
            ArrayList lst = new ArrayList();

            // Code sẽ tự tìm class Faculty bên file Faculty.cs
            lst.Add(new Faculty("K01", "Công nghệ thông tin", 1200));
            lst.Add(new Faculty("K02", "Quản trị kinh doanh", 4200));
            lst.Add(new Faculty("K03", "Kế toán tài chính", 5200));
            lst.Add(new Faculty("K04", "Ngôn ngữ Anh", 2000));

            return lst;
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void Form14_Load(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu
            ArrayList lst = GetData();

            // 2. Đổ dữ liệu vào ComboBox
            cbFaculty.DataSource = lst;

            // 3. Chọn cột hiển thị (Người dùng nhìn thấy Tên)
            cbFaculty.DisplayMember = "Name";

            // 4. Chọn giá trị ngầm (Mặc định lấy Mã)
            cbFaculty.ValueMember = "Id";
        }

        // --- KHI CHỌN DÒNG KHÁC (Hiển thị Mã) ---
        private void Cb_Faculty_SelectedValueChanged(object sender, EventArgs e)
        {
            // Nếu chưa có dữ liệu thì thoát để tránh lỗi
            if (cbFaculty.DataSource == null) return;
            if (cbFaculty.SelectedValue == null) return;

            // Đổi ValueMember thành "Id" để lấy Mã Khoa
            cbFaculty.ValueMember = "Id";

            // Ép kiểu về string an toàn
            string id = "";
            if (cbFaculty.SelectedValue != null)
                id = cbFaculty.SelectedValue.ToString();

            tbDisplay.Text = "Bạn đã chọn khoa có mã: " + id;
        }

        // --- KHI BẤM OK (Hiển thị Tên) ---
        private void BtOK_Click(object sender, EventArgs e)
        {
            // Đổi ValueMember thành "Name" để lấy Tên Khoa (Minh họa)
            cbFaculty.ValueMember = "Name";

            string name = "";
            if (cbFaculty.SelectedValue != null)
                name = cbFaculty.SelectedValue.ToString();

            tbDisplay.Text = "Bạn đã chọn khoa có tên: " + name;
        }
    }

    // ĐÃ XÓA CLASS FACULTY Ở ĐÂY ĐỂ TRÁNH LỖI TRÙNG LẶP
}