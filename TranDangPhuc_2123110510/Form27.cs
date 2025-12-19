using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form27 : Form
    {
        // Biến toạ độ logic
        private int xEgg = 300;
        private int yEgg = 0;
        private int yDelta = 5;

        public Form27()
        {
            InitializeComponent(); // Gọi giao diện từ Designer
            InitGameLogic();       // Thiết lập logic bổ sung
        }

        private void InitGameLogic()
        {
            // Đồng bộ toạ độ code với toạ độ thiết kế ban đầu
            xEgg = pbEgg.Location.X;
            yEgg = pbEgg.Location.Y;

            // Load ảnh (Phần này phải để ở code logic để dùng try-catch)
            try
            {
                pbEgg.ImageLocation = "Images/egg_gold.png";
            }
            catch
            {
                MessageBox.Show("Không tìm thấy ảnh! Hãy kiểm tra lại thư mục Images.");
            }

            // Bắt đầu timer
            tmEgg.Start();
        }

        private void TmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDelta;

            // Kiểm tra chạm đất
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                // Đổi sang ảnh trứng vỡ khi chạm đất
                try
                {
                    pbEgg.ImageLocation = "Images/egg_gold_broken.png";
                }
                catch { }

                tmEgg.Stop();
                MessageBox.Show("Oop! Trứng vỡ rồi!");
                return;
            }

            pbEgg.Location = new Point(xEgg, yEgg);
        }
    }
}