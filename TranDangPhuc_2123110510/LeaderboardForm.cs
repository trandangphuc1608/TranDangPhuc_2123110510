using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace TranDangPhuc_2123110510
{
    public partial class LeaderboardForm : Form
    {
        private DataGridView dgvLeaderboard;
        private Label lblTitle;
        private Button btnBack;
        private Panel panelHeader;

        public LeaderboardForm()
        {
            InitializeComponent();
            SetupUI();
            LoadLeaderboardData();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Bảng Xếp Hạng";
            this.Size = new Size(500, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // 2. Tạo Panel tiêu đề (Header) - Dock Top
            panelHeader = new Panel();
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 80;
            panelHeader.BackColor = Color.FromArgb(255, 193, 7); // Màu vàng
            this.Controls.Add(panelHeader);

            lblTitle = new Label();
            lblTitle.Text = "🏆 TOP 10 CAO THỦ 🏆";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = false;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Fill;
            panelHeader.Controls.Add(lblTitle);

            // 3. Tạo Nút Quay lại - Dock Bottom
            btnBack = new Button();
            btnBack.Text = "QUAY LẠI MENU";
            btnBack.Height = 50;
            btnBack.Dock = DockStyle.Bottom;
            btnBack.BackColor = Color.FromArgb(107, 114, 128);
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnBack);

            // 4. Tạo Bảng dữ liệu - Dock Fill
            dgvLeaderboard = new DataGridView();
            dgvLeaderboard.Dock = DockStyle.Fill; // Tự động lấp đầy khoảng trống còn lại
            dgvLeaderboard.BackgroundColor = Color.White;
            dgvLeaderboard.BorderStyle = BorderStyle.None;
            dgvLeaderboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaderboard.RowHeadersVisible = false;
            dgvLeaderboard.AllowUserToAddRows = false;
            dgvLeaderboard.ReadOnly = true;
            dgvLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvLeaderboard.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvLeaderboard.DefaultCellStyle.Padding = new Padding(5);
            dgvLeaderboard.RowTemplate.Height = 35;

            // Header bảng
            dgvLeaderboard.EnableHeadersVisualStyles = false;
            dgvLeaderboard.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            dgvLeaderboard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLeaderboard.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvLeaderboard.ColumnHeadersHeight = 40;

            this.Controls.Add(dgvLeaderboard);

            // [QUAN TRỌNG NHẤT] Sửa lỗi bị che khuất
            // Đưa GridView lên lớp trên cùng để nó tự tính toán lại vị trí so với Panel Header
            dgvLeaderboard.BringToFront();
            // Không gọi panelHeader.BringToFront() nữa vì nó sẽ đè lên Grid
        }

        private void LoadLeaderboardData()
        {
            try
            {
                DatabaseUtils db = new DatabaseUtils();

                // Câu lệnh SQL lấy Top 10
                string sql = @"
                    SELECT TOP 10 
                        ROW_NUMBER() OVER(ORDER BY HighScore DESC) AS [Hạng], 
                        Username AS [Tên Nhân Vật], 
                        HighScore AS [Điểm Kỷ Lục] 
                    FROM Users";

                DataTable dt = db.GetData(sql);
                dgvLeaderboard.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu bảng xếp hạng!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng xếp hạng: " + ex.Message, "Lỗi Hệ Thống");
            }
        }
    }
}