using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data; // [QUAN TRỌNG] Cần thêm thư viện này để dùng DataTable

namespace TranDangPhuc_2123110510
{
    public partial class LoginForm : Form
    {
        // [XÓA] Không dùng Dictionary tĩnh nữa vì đã có Database
        // public static Dictionary<string, string> accounts ...

        private Image eyeIcon;
        private Image eyeOffIcon;

        public LoginForm()
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
            panelHeader.BackColor = Color.FromArgb(59, 130, 246);
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            // Input field styling
            txtUser.BackColor = Color.White;
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 10);

            txtPass.BackColor = Color.White;
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 10);

            // Button styling
            btnLogin.BackColor = Color.FromArgb(59, 130, 246);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.Cursor = Cursors.Hand;

            // Link buttons
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.BackColor = Color.Transparent;
            btnForgotPassword.ForeColor = Color.FromArgb(59, 130, 246);
            btnForgotPassword.Cursor = Cursors.Hand;

            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.BackColor = Color.Transparent;
            btnRegister.ForeColor = Color.FromArgb(59, 130, 246);
            btnRegister.Cursor = Cursors.Hand;
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
                    picShowPass.Image = eyeOffIcon;
                    picShowPass.Parent = txtPass;
                    picShowPass.Location = new Point(txtPass.Width - picShowPass.Width - 10,
                                                   (txtPass.Height - picShowPass.Height) / 2);
                    picShowPass.BringToFront();
                }
                else
                {
                    picShowPass.Visible = false;
                }
            }
            catch (Exception)
            {
                picShowPass.Visible = false;
            }
        }

        // --- [SỬA ĐỔI QUAN TRỌNG Ở ĐÂY] ---
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;

            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. [MỚI] Kết nối Database để kiểm tra
            try
            {
                DatabaseUtils db = new DatabaseUtils(); // Gọi class kết nối

                // Tạo câu lệnh SQL tìm user và pass tương ứng
                // Lưu ý: pass nên được mã hóa, nhưng ở đây ta làm đơn giản trước
                string sql = $"SELECT * FROM Users WHERE Username = '{user}' AND Password = '{pass}'";

                // Lấy dữ liệu về
                DataTable dt = db.GetData(sql);

                // 3. Kiểm tra kết quả
                if (dt.Rows.Count > 0)
                {
                    // Có tìm thấy tài khoản -> Đăng nhập thành công
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide(); // Ẩn form Login

                    // Mở Form Menu và truyền tên người dùng sang để hiển thị "Xin chào..."
                    MenuForm menu = new MenuForm(user);
                    menu.ShowDialog();

                    this.Show(); // Hiện lại Login khi thoát game
                }
                else
                {
                    // Không tìm thấy dòng nào -> Sai thông tin
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi Đăng Nhập",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Show();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên để reset mật khẩu!", "Quên mật khẩu",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picShowPass_Click(object sender, EventArgs e)
        {
            if (eyeIcon == null || eyeOffIcon == null) return;

            if (txtPass.UseSystemPasswordChar)
            {
                txtPass.UseSystemPasswordChar = false;
                picShowPass.Image = eyeIcon;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                picShowPass.Image = eyeOffIcon;
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(59, 130, 246);
        }
    }
}