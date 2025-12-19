using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form23 : Form
    {
        // BindingSource và List dữ liệu
        BindingSource bs = new BindingSource();
        List<Employee> lst = new List<Employee>();

        public Form23()
        {
            InitializeComponent();
            SetupDataGridView(); // Cấu hình cột cho Grid
        }

        private void SetupDataGridView()
        {
            dgvEmployee.AutoGenerateColumns = false; // Tắt tự động sinh cột

            // 1. Cột ID
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.HeaderText = "Mã NV";
            colId.DataPropertyName = "Id"; // Map với thuộc tính Id của Employee
            colId.Width = 100;
            dgvEmployee.Columns.Add(colId);

            // 2. Cột Name
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.HeaderText = "Tên nhân viên";
            colName.DataPropertyName = "Name";
            colName.Width = 200;
            dgvEmployee.Columns.Add(colName);

            // 3. Cột Age
            DataGridViewTextBoxColumn colAge = new DataGridViewTextBoxColumn();
            colAge.HeaderText = "Tuổi";
            colAge.DataPropertyName = "Age";
            colAge.Width = 80;
            dgvEmployee.Columns.Add(colAge);

            // 4. Cột Gender
            DataGridViewCheckBoxColumn colGen = new DataGridViewCheckBoxColumn();
            colGen.HeaderText = "Nam?";
            colGen.DataPropertyName = "Gender";
            colGen.Width = 80;
            dgvEmployee.Columns.Add(colGen);
        }

        // Tạo dữ liệu giả
        public List<Employee> GetData()
        {
            List<Employee> listEm = new List<Employee>();
            listEm.Add(new Employee() { Id = "NV01", Name = "Lê Lợi", Age = 30, Gender = true });
            listEm.Add(new Employee() { Id = "NV02", Name = "Nguyễn Trãi", Age = 28, Gender = true });
            return listEm;
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            lst = GetData();
            bs.DataSource = lst;
            dgvEmployee.DataSource = bs; // Gán BindingSource vào Grid
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;
            int a = 0; int.TryParse(tbAge.Text, out a); em.Age = a;
            em.Gender = ckGender.Checked;

            bs.Add(em); // Thêm vào BindingSource
            bs.MoveLast(); // Di chuyển đến dòng cuối
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow != null)
            {
                bs.RemoveCurrent(); // Xóa dòng hiện tại qua BindingSource
            }
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Binding ngược dữ liệu lên TextBox khi chọn dòng
            if (dgvEmployee.Rows[e.RowIndex].Cells[0].Value != null)
            {
                tbId.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbAge.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();

                string sGen = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
                ckGender.Checked = (sGen.ToLower() == "true");
            }
        }
    }
}