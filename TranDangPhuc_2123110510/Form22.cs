using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form22 : Form
    {
        // Danh sách quản lý dữ liệu ngầm
        List<Employee> lst = new List<Employee>();

        public Form22()
        {
            InitializeComponent();
        }

        // --- HÀM TẠO DỮ LIỆU GIẢ ---
        public List<Employee> GetData()
        {
            List<Employee> listEm = new List<Employee>();
            // Code sẽ tự tìm thấy class Employee bên file Employee.cs
            listEm.Add(new Employee() { Id = "53418", Name = "Trần Tiến", Age = 20, Gender = true });
            listEm.Add(new Employee() { Id = "53416", Name = "Nguyễn Cường", Age = 25, Gender = false });
            listEm.Add(new Employee() { Id = "53417", Name = "Nguyễn Hào", Age = 23, Gender = true });
            return listEm;
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void Form22_Load(object sender, EventArgs e)
        {
            lst = GetData();

            // Đổ dữ liệu từ List lên DataGridView
            foreach (Employee em in lst)
            {
                dgvEmployee.Rows.Add(em.Id, em.Name, em.Age, em.Gender);
            }
        }

        // --- SỰ KIỆN THÊM ---
        private void BtAdd_Click(object sender, EventArgs e)
        {
            // 1. Tạo đối tượng mới lấy từ giao diện
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;

            int a = 0;
            int.TryParse(tbAge.Text, out a);
            em.Age = a;

            em.Gender = ckGender.Checked;

            // 2. Thêm vào List (Quản lý ngầm)
            lst.Add(em);

            // 3. Thêm vào Grid (Hiển thị)
            dgvEmployee.Rows.Add(em.Id, em.Name, em.Age, em.Gender);
        }

        // --- SỰ KIỆN XÓA ---
        private void BtDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn không
            if (dgvEmployee.CurrentRow == null || dgvEmployee.CurrentRow.IsNewRow) return;

            int idx = dgvEmployee.CurrentCell.RowIndex;

            // Xóa trong List (nếu index hợp lệ)
            if (idx >= 0 && idx < lst.Count)
            {
                lst.RemoveAt(idx);
            }

            // Xóa trên Grid
            dgvEmployee.Rows.RemoveAt(idx);
        }

        // --- SỰ KIỆN THOÁT ---
        private void BtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- SỰ KIỆN CHỌN DÒNG (BINDING NGƯỢC) ---
        private void DgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            // Kiểm tra index hợp lệ và đảm bảo dòng đó có dữ liệu
            if (idx >= 0 && idx < dgvEmployee.Rows.Count - 1 && dgvEmployee.Rows[idx].Cells[0].Value != null)
            {
                tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
                tbAge.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();

                string sGen = dgvEmployee.Rows[idx].Cells[3].Value.ToString();
                ckGender.Checked = bool.Parse(sGen);
            }
        }
    }
}