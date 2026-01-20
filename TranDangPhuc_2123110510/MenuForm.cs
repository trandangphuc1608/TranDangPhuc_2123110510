using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class MenuForm : Form
    {
        // Biến lưu tên người dùng để truyền sang Game
        private string currentUsername;

        public MenuForm(string username)
        {
            InitializeComponent();

            // 1. Lưu lại tên người dùng
            this.currentUsername = username;
            this.Text = "Xin chào " + username + " - Danh sách bài tập";

            Tao30Nut();
        }

        void Tao30Nut()
        {
            for (int i = 1; i <= 31; i++)
            {
                Button btn = new Button();
                btn.Text = "Bài " + i;
                btn.Size = new Size(100, 50);
                btn.Margin = new Padding(10);
                btn.Tag = i; // Lưu số thứ tự bài vào Tag để dùng sau này
                btn.Cursor = Cursors.Hand;

                // Tô màu riêng cho Bài 31 (Game)
                if (i == 31)
                {
                    btn.BackColor = Color.LightGreen;
                    btn.Text = "GAME (Bài 31)";
                    btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }

                btn.Click += Btn_Click; // Gắn sự kiện click
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int baiSo = (int)btn.Tag; // Lấy số thứ tự bài

            switch (baiSo)
            {
                // --- CÁC BÀI TẬP TỪ 1 ĐẾN 30 ---

                case 1: new Form1().ShowDialog(); break;
                case 2: new Form2().ShowDialog(); break;
                case 3: new Form3().ShowDialog(); break;
                case 4: new Form4().ShowDialog(); break;
                case 5: new Form5().ShowDialog(); break;
                case 6: new Form6().ShowDialog(); break;
                case 7: new Form7().ShowDialog(); break;
                case 8: new Form8().ShowDialog(); break;
                case 9: new Form9().ShowDialog(); break;
                case 10: new Form10().ShowDialog(); break;

                case 11: new Form11().ShowDialog(); break;
                case 12: new Form12().ShowDialog(); break;
                case 13: new Form13().ShowDialog(); break;
                case 14: new Form14().ShowDialog(); break;
                case 15: new Form15().ShowDialog(); break;
                case 16: new Form16().ShowDialog(); break;
                case 17: new Form17().ShowDialog(); break;
                case 18: new Form18().ShowDialog(); break;
                case 19: new Form19().ShowDialog(); break;
                case 20: new Form20().ShowDialog(); break;

                case 21: new Form21().ShowDialog(); break;
                case 22: new Form22().ShowDialog(); break;
                case 23: new Form23().ShowDialog(); break;
                case 24: new Form24().ShowDialog(); break;
                case 25: new Form25().ShowDialog(); break;
                case 26: new Form26().ShowDialog(); break;
                case 27: new Form27().ShowDialog(); break;
                case 28: new Form28().ShowDialog(); break;
                case 29: new Form29().ShowDialog(); break;
                case 30: new Form30().ShowDialog(); break;

                // --- BÀI 31: GAME BẮN GÀ ---
                case 31:
                    // Truyền tên người chơi vào Form Game
                    // (Bạn sẽ xem bảng xếp hạng ở trong Form Game này)
                    Form31 game = new Form31(this.currentUsername);
                    game.ShowDialog();
                    break;

                default:
                    MessageBox.Show("Bài tập số " + baiSo + " chưa được định nghĩa!", "Thông báo");
                    break;
            }
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối Database khi mở Menu
            try
            {
                DatabaseUtils db = new DatabaseUtils();
                if (!db.Connect())
                {
                    MessageBox.Show("Cảnh báo: Không kết nối được Database!", "Lỗi hệ thống");
                }
                else
                {
                    db.Disconnect();
                }
            }
            catch { }
        }
    }
}