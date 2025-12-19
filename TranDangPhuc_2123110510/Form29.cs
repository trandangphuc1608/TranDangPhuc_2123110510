using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form29 : Form
    {
        // Các biến Logic (Toạ độ, Điểm số...) giữ nguyên ở đây
        private int score = 0;

        // Toạ độ & Tốc độ
        private int xBasket = 300;
        private int yBasket = 500; // Sẽ được cập nhật lại theo size form
        private int xDeltaBasket = 30;

        private int xChicken = 300;
        private int yChicken = 10;
        private int xDeltaChicken = 5;

        private int xEgg = 300;
        private int yEgg = 10;
        private int yDeltaEgg = 8;

        public Form29()
        {
            InitializeComponent(); // Gọi giao diện từ file Designer

            // --- THIẾT LẬP LOGIC BAN ĐẦU ---
            // Cập nhật lại vị trí rổ cho khớp với Designer (sát đáy)
            yBasket = this.ClientSize.Height - 120;
            pbBasket.Location = new Point(xBasket, yBasket);

            // Load hình ảnh (Phần này Designer không làm được try-catch nên để ở đây)
            try { pbEgg.ImageLocation = "Images/egg_gold.png"; } catch { pbEgg.BackColor = Color.Gold; }
            try { pbChicken.ImageLocation = "Images/chicken.png"; } catch { pbChicken.BackColor = Color.Yellow; }
            try { pbBasket.ImageLocation = "Images/basket.png"; } catch { pbBasket.BackColor = Color.Brown; }

            // Bắt đầu game
            ResetGame();
        }

        // --- HÀM KHỞI ĐỘNG / RESET GAME ---
        private void ResetGame()
        {
            score = 0;
            lblScore.Text = "Score: 0";

            // Đưa trứng về trạng thái ảnh nguyên vẹn
            try { pbEgg.ImageLocation = "Images/egg_gold.png"; } catch { }

            ResetEggToChicken();

            btReplay.Visible = false; // Ẩn nút chơi lại
            tmEgg.Start();
            tmChicken.Start();
            this.Focus(); // Để bắt sự kiện bàn phím ngay
        }

        private void TmChicken_Tick(object sender, EventArgs e)
        {
            xChicken += xDeltaChicken;
            if (xChicken > this.ClientSize.Width - pbChicken.Width || xChicken <= 0)
                xDeltaChicken = -xDeltaChicken;

            pbChicken.Location = new Point(xChicken, yChicken);

            // [QUAN TRỌNG] Luôn giữ gà ở lớp trên cùng để che trứng
            pbChicken.BringToFront();
            // Giữ nút Replay (nếu hiện) ở trên gà luôn
            if (btReplay.Visible) btReplay.BringToFront();
        }

        private void TmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDeltaEgg;
            pbEgg.Location = new Point(xEgg, yEgg);

            // Xử lý Hứng Trứng
            if (pbEgg.Bounds.IntersectsWith(pbBasket.Bounds))
            {
                score++;
                lblScore.Text = "Score: " + score;
                ResetEggToChicken();
                return;
            }

            // Xử lý Chạm Đất (Game Over)
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                try { pbEgg.ImageLocation = "Images/egg_gold_broken.png"; } catch { }

                tmEgg.Stop();
                tmChicken.Stop();

                // Hiện nút chơi lại
                btReplay.Visible = true;
                btReplay.BringToFront();
            }
        }

        private void ResetEggToChicken()
        {
            // Để trứng nằm chính giữa con gà theo chiều ngang
            xEgg = pbChicken.Location.X + (pbChicken.Width - pbEgg.Width) / 2;

            // [QUAN TRỌNG] Để Y của trứng bằng Y của gà -> Trứng sẽ nằm TRONG vùng ảnh của gà
            // Vì gà được BringToFront nên gà sẽ CHE KHUẤT trứng
            yEgg = pbChicken.Location.Y + 20;

            pbEgg.Location = new Point(xEgg, yEgg);

            // Đẩy trứng xuống lớp dưới cùng cho chắc chắn
            pbEgg.SendToBack();
        }

        private void Form29_KeyDown(object sender, KeyEventArgs e)
        {
            if (tmEgg.Enabled == false) return; // Game over thì không cho di chuyển rổ

            if (e.KeyValue == 39 && xBasket < this.ClientSize.Width - pbBasket.Width)
                xBasket += xDeltaBasket;
            else if (e.KeyValue == 37 && xBasket > 0)
                xBasket -= xDeltaBasket;

            pbBasket.Location = new Point(xBasket, yBasket);
        }

        // Sự kiện bấm nút Chơi Lại
        private void BtReplay_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}