using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        // --- SỰ KIỆN 1: KHI CHỌN NGÀY KHÁC ---
        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            // Lấy ngày tháng năm (Short Date: dd/MM/yyyy)
            this.Text = "Short Date: " + dtpDate.Value.ToShortDateString();
        }

        // --- SỰ KIỆN 2: KHI BẤM OK ---
        private void BtOK_Click(object sender, EventArgs e)
        {
            // Lấy ngày tháng đầy đủ (Long Date: Thứ, ngày, tháng, năm...)
            this.Text = "Long Date: " + dtpDate.Value.ToLongDateString();
        }
    }
}