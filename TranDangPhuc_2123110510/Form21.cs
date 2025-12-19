using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();

            // Thêm vài dữ liệu mẫu để test
            dgvEmployee.Rows.Add("53418", "Trần Tiến", "20", true);
            dgvEmployee.Rows.Add("53416", "Nguyễn Cường", "25", false);
        }

        // --- CHỨC NĂNG 1: THÊM DÒNG MỚI ---
        private void BtAdd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox đưa vào Grid
            dgvEmployee.Rows.Add(tbId.Text, tbName.Text, tbAge.Text, ckGender.Checked);

            // Xóa trắng ô nhập sau khi thêm
            tbId.Clear();
            tbName.Clear();
            tbAge.Clear();
            ckGender.Checked = false;
        }

        // --- CHỨC NĂNG 2: XÓA DÒNG ĐANG CHỌN ---
        private void BtDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang chọn không
            if (dgvEmployee.CurrentRow != null && !dgvEmployee.CurrentRow.IsNewRow)
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }
        }

        // --- CHỨC NĂNG 3: THOÁT ---
        private void BtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- CHỨC NĂNG 4: CLICK VÀO LƯỚI -> HIỆN XUỐNG TEXTBOX ---
        private void DgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            // Kiểm tra an toàn: Nếu idx hợp lệ và dòng đó không phải dòng trống
            if (idx >= 0 && idx < dgvEmployee.Rows.Count - 1)
            {
                // Lấy giá trị từng cột (Cells 0, 1, 2, 3)
                // Lưu ý: Cần kiểm tra null để tránh lỗi nếu ô đó trống
                if (dgvEmployee.Rows[idx].Cells[0].Value != null)
                    tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[1].Value != null)
                    tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[2].Value != null)
                    tbAge.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();

                // Cột CheckBox (Cells[3])
                if (dgvEmployee.Rows[idx].Cells[3].Value != null)
                {
                    // Chuyển đổi giá trị về true/false
                    string val = dgvEmployee.Rows[idx].Cells[3].Value.ToString();
                    ckGender.Checked = (val.ToLower() == "true");
                }
            }
        }
    }
}