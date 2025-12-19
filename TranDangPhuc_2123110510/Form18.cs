using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
            InitData(); // Nạp dữ liệu
        }

        private void InitData()
        {
            // Thêm dữ liệu mẫu giống Slide 116
            lbSong.Items.AddRange(new string[] {
                "Giấc mơ Chapi",
                "Đôi mắt Pleiku",
                "Em Muốn Sống Bên Anh Trọn Đời",
                "H'Zen Lên Rẫy",
                "Ly Cà Phê Ban Mê",
                "Đi tìm lời ru mặt trời"
            });
        }

        // --- XỬ LÝ 1: CHUYỂN 1 BÀI TỪ TRÁI QUA PHẢI (>) ---
        private void BtSelect_Click(object sender, EventArgs e)
        {
            if (lbSong.SelectedIndex != -1) // Phải có bài đang chọn
            {
                string song = lbSong.SelectedItem.ToString();
                lbFavorite.Items.Add(song);          // Thêm sang phải
                lbSong.Items.RemoveAt(lbSong.SelectedIndex); // Xóa bên trái
            }
        }

        // --- XỬ LÝ 2: CHUYỂN TẤT CẢ TỪ TRÁI QUA PHẢI (>>) ---
        private void BtSelectAll_Click(object sender, EventArgs e)
        {
            // Cách an toàn nhất: Copy hết sang rồi xóa gốc
            lbFavorite.Items.AddRange(lbSong.Items);
            lbSong.Items.Clear();
        }

        // --- XỬ LÝ 3: CHUYỂN 1 BÀI TỪ PHẢI VỀ TRÁI (<) ---
        private void BtDeselect_Click(object sender, EventArgs e)
        {
            if (lbFavorite.SelectedIndex != -1)
            {
                string song = lbFavorite.SelectedItem.ToString();
                lbSong.Items.Add(song);              // Trả về bên trái
                lbFavorite.Items.RemoveAt(lbFavorite.SelectedIndex); // Xóa bên phải
            }
        }

        // --- XỬ LÝ 4: CHUYỂN TẤT CẢ TỪ PHẢI VỀ TRÁI (<<) ---
        private void BtDeselectAll_Click(object sender, EventArgs e)
        {
            lbSong.Items.AddRange(lbFavorite.Items);
            lbFavorite.Items.Clear();
        }

        // --- XỬ LÝ 5: DOUBLE CLICK ĐỂ CHỌN NHANH ---
        private void LbSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbSong.IndexFromPoint(e.Location); // Lấy vị trí chuột
            if (index != ListBox.NoMatches)
            {
                string song = lbSong.Items[index].ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(index);
            }
        }

        private void LbFavorite_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbFavorite.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string song = lbFavorite.Items[index].ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(index);
            }
        }
    }
}