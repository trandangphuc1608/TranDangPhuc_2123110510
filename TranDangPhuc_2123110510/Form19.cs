using System;
using System.Collections;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form19 : Form
    {
        // Danh sách gốc
        ArrayList listSong = new ArrayList();

        public Form19()
        {
            InitializeComponent();
        }

        // --- HÀM TẠO DỮ LIỆU GIẢ ---
        private ArrayList GetData()
        {
            ArrayList lst = new ArrayList();
            // Code sẽ tự tìm class Song bên file Song.cs
            lst.Add(new Song(53418, "Giấc mơ Chapi", "Trần Tiến"));
            lst.Add(new Song(52616, "Đôi mắt Pleiku", "Nguyễn Cường"));
            lst.Add(new Song(51172, "Em Muốn Sống Bên Anh Trọn Đời", "Nguyễn Cường"));
            lst.Add(new Song(52300, "Ly Cà Phê Ban Mê", "Nguyễn Cường"));
            return lst;
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void Form19_Load(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu
            listSong = GetData();

            // 2. Đổ vào ListBox
            lbSong.DataSource = listSong;

            // 3. Chọn cột hiển thị (Tên bài hát)
            lbSong.DisplayMember = "Name";

            // (Tùy chọn) Giá trị ngầm là Id
            lbSong.ValueMember = "Id";
        }

        // --- SỰ KIỆN CHỌN (>) ---
        private void BtSelect_Click(object sender, EventArgs e)
        {
            if (lbSong.SelectedItem != null)
            {
                // Ép kiểu đối tượng đang chọn về class Song
                Song song = (Song)lbSong.SelectedItem;

                // Lấy thông tin
                string id = song.Id.ToString();
                string name = song.Name;
                string author = song.Author;

                // Tạo chuỗi hiển thị và thêm vào danh sách bên phải
                string displayString = id + " - " + name + " - " + author;
                lbFavorite.Items.Add(displayString);
            }
        }
    }
}