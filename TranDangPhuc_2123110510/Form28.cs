using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form28 : Form
    {
        // --- KHAI BÁO BIẾN LOGIC ---

        // Quả trứng
        private int xEgg = 300;
        private int yEgg = 0;
        private int yDeltaEgg = 5;

        // Chiếc rổ
        private int xBasket = 300;
        private int yBasket = 500;
        private int xDeltaBasket = 30; // Tốc độ di chuyển của rổ

        public Form28()
        {
            InitializeComponent(); // Gọi giao diện từ Designer
            InitGameLogic();       // Thiết lập các thông số logic thêm
        }

        private void InitGameLogic()
        {
            // 1. Cài đặt vị trí ban đầu cho biến Logic khớp với Designer
            xEgg = pbEgg.Location.X;
            yEgg = pbEgg.Location.Y;

            // Tính toán vị trí Y để rổ nằm sát đáy (Cách đáy 100px)
            yBasket = this.ClientSize.Height - 100;
            xBasket = pbBasket.Location.X;
            pbBasket.Location = new Point(xBasket, yBasket);

            // 2. Load hình ảnh an toàn (Try-Catch)
            // Phần này không để trong Designer được vì Designer không hỗ trợ try-catch
            try
            {
                pbEgg.ImageLocation = "Images/egg_gold.png";
            }
            catch { }

            try
            {
                pbBasket.ImageLocation = "Images/basket.png";
            }
            catch
            {
                // Nếu chưa có ảnh, vẽ tạm hình chữ nhật màu nâu
                pbBasket.Paint += (s, e) => { e.Graphics.FillRectangle(Brushes.SaddleBrown, 0, 0, 100, 100); };
            }

            // 3. Bắt đầu Timer
            tmGame.Start();
        }

        // --- XỬ LÝ PHÍM BẤM (DI CHUYỂN RỔ) ---
        private void Form28_KeyDown(object sender, KeyEventArgs e)
        {
            // Phím Mũi tên Phải (Right Arrow)
            if (e.KeyValue == 39)
            {
                if (xBasket < this.ClientSize.Width - pbBasket.Width)
                {
                    xBasket += xDeltaBasket;
                }
            }

            // Phím Mũi tên Trái (Left Arrow)
            if (e.KeyValue == 37)
            {
                if (xBasket > 0)
                {
                    xBasket -= xDeltaBasket;
                }
            }

            // Cập nhật vị trí rổ
            pbBasket.Location = new Point(xBasket, yBasket);
        }

        // --- XỬ LÝ GAME LOOP (TRỨNG RƠI) ---
        private void TmGame_Tick(object sender, EventArgs e)
        {
            yEgg += yDeltaEgg;

            // Kiểm tra trứng chạm đất (Game Over)
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                try { pbEgg.ImageLocation = "Images/egg_gold_broken.png"; } catch { }

                tmGame.Stop();
                MessageBox.Show("Rớt rồi! Game Over.");
                return;
            }

            // Cập nhật vị trí trứng
            pbEgg.Location = new Point(xEgg, yEgg);
        }
    }
}