using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form26 : Form
    {
        // Biến toạ độ và tốc độ
        private int xBall = 0;
        private int yBall = 0;
        private int xDelta = 5;
        private int yDelta = 5;

        public Form26()
        {
            InitializeComponent(); // Gọi giao diện từ Designer
            InitGameLogic();       // Thiết lập logic bổ sung
        }

        private void InitGameLogic()
        {
            // 1. Xử lý vẽ bóng đỏ (Designer không hỗ trợ lambda expression tốt nên để ở đây)
            pbBall.Paint += (s, e) => {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(Brushes.Red, 0, 0, pbBall.Width - 1, pbBall.Height - 1);
            };

            // 2. Bắt đầu game
            tmGame.Start();
        }

        private void TmGame_Tick(object sender, EventArgs e)
        {
            // Cập nhật toạ độ
            xBall += xDelta;
            yBall += yDelta;

            // Va chạm chiều ngang (Trái/Phải)
            if (xBall > this.ClientSize.Width - pbBall.Width || xBall <= 0)
            {
                xDelta = -xDelta;
            }

            // Va chạm chiều dọc (Trên/Dưới)
            if (yBall > this.ClientSize.Height - pbBall.Height || yBall <= 0)
            {
                yDelta = -yDelta;
            }

            // Cập nhật vị trí mới cho PictureBox
            pbBall.Location = new Point(xBall, yBall);
        }
    }
}