using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data; // [CẦN THÊM] Thư viện xử lý dữ liệu

namespace TranDangPhuc_2123110510
{
    public partial class RegisterForm : Form
    {
        private Image eyeIcon;
        private Image eyeOffIcon;

        public RegisterForm()
        {
            InitializeComponent();
            ApplyModernStyle();
            LoadIcons();
        }

        private void ApplyModernStyle()
        {
            // Form styling
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Padding = new Padding(20);

            // Panel styling
            panelHeader.BackColor = Color.FromArgb(16, 185, 129);
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            // Input field styling
            txtUser.BackColor = Color.White;
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 10);

            txtPass.BackColor = Color.White;
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 10);

            txtConfirmPass.BackColor = Color.White;
            txtConfirmPass.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPass.Font = new Font("Segoe UI", 10);

            // Button styling
            btnRegister.BackColor = Color.FromArgb(16, 185, 129);
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnRegister.Cursor = Cursors.Hand;

            btnBack.BackColor = Color.FromArgb(107, 114, 128);
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
        }

        private void LoadIcons()
        {
            string path = Application.StartupPath;
            try
            {
                if (File.Exists(Path.Combine(path, "eye.png")))
                    eyeIcon = Image.FromFile(Path.Combine(path, "eye.png"));

                if (File.Exists(Path.Combine(path, "eye-off.png")))
                    eyeOffIcon = Image.FromFile(Path.Combine(path, "eye-off.png"));

                if (eyeOffIcon != null)
                {
                    picShowPass.Parent = txtPass;
                    picShowPass.Location = new Point(txtPass.Width - picShowPass.Width - 10,
                                                   (txtPass.Height - picShowPass.Height) / 2);
                    picShowPass.BringToFront();
                    picShowPass.Image = eyeOffIcon;

                    picShowConfirm.Parent = txtConfirmPass;
                    picShowConfirm.Location = new Point(txtConfirmPass.Width - picShowConfirm.Width - 10,
                                                      (txtConfirmPass.Height - picShowConfirm.Height) / 2);
                    picShowConfirm.BringToFront();
                    picShowConfirm.Image = eyeOffIcon;
                }
                else
                {
                    picShowPass.Visible = false;
                    picShowConfirm.Visible = false;
                }
            }
            catch (Exception)
            {
                picShowPass.Visible = false;
                picShowConfirm.Visible = false;
            }
        }

        // --- [PHẦN SỬA ĐỔI QUAN TRỌNG: KẾT NỐI DATABASE] ---
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;
            string confirm = txtConfirmPass.Text;

            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kết nối Database để đăng ký
            try
            {
                DatabaseUtils db = new DatabaseUtils();

                // BƯỚC 1: Kiểm tra xem tên đăng nhập đã tồn tại chưa
                string checkSql = $"SELECT * FROM Users WHERE Username = '{user}'";
                DataTable dt = db.GetData(checkSql);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!\nVui lòng chọn tên khác.", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // BƯỚC 2: Nếu chưa tồn tại -> Thêm mới vào Database
                    // (Mặc định điểm HighScore là 0)
                    string insertSql = $"INSERT INTO Users (Username, Password, HighScore) VALUES ('{user}', '{pass}', 0)";

                    if (db.ExecuteQuery(insertSql))
                    {
                        MessageBox.Show("Đăng ký thành công!\nBạn có thể đăng nhập ngay bây giờ.", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form Đăng ký để quay về Đăng nhập
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại do lỗi hệ thống!", "Lỗi",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Database: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picShowPass_Click(object sender, EventArgs e)
        {
            if (eyeIcon == null || eyeOffIcon == null) return;
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;
            picShowPass.Image = txtPass.UseSystemPasswordChar ? eyeOffIcon : eyeIcon;
        }

        private void picShowConfirm_Click(object sender, EventArgs e)
        {
            if (eyeIcon == null || eyeOffIcon == null) return;
            txtConfirmPass.UseSystemPasswordChar = !txtConfirmPass.UseSystemPasswordChar;
            picShowConfirm.Image = txtConfirmPass.UseSystemPasswordChar ? eyeOffIcon : eyeIcon;
        }

        // Hover effects
        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(5, 150, 105);
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(16, 185, 129);
        }

        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(75, 85, 99);
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(107, 114, 128);
        }
    }
}