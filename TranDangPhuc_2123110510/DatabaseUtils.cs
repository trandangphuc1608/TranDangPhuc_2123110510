using System;
using System.Data;
using System.Data.SqlClient; // Thư viện kết nối SQL
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public class DatabaseUtils
    {
        // --- CẤU HÌNH CHUỖI KẾT NỐI (QUAN TRỌNG) ---
        // 1. Data Source: Tên máy chủ SQL của bạn (Ví dụ: .\SQLEXPRESS hoặc DESKTOP-XXX)
        // 2. Initial Catalog: Tên Database bạn đã tạo
        // 3. Integrated Security=True: Đăng nhập bằng quyền Windows (không cần mật khẩu)
        private string strConnect = @"Data Source=.;Initial Catalog=ChickenGameDB;Integrated Security=True";

        private SqlConnection conn = null;

        public DatabaseUtils()
        {
            conn = new SqlConnection(strConnect);
        }

        // 1. Hàm mở kết nối
        public bool Connect()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Database: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 2. Hàm đóng kết nối
        public void Disconnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        // 3. Hàm lấy dữ liệu (SELECT) đổ vào bảng (DataTable)
        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return dt;
        }

        // 4. Hàm thực hiện lệnh thêm/xóa/sửa (INSERT, UPDATE, DELETE)
        public bool ExecuteQuery(string sql)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}