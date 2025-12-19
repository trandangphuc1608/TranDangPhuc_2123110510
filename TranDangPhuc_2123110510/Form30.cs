using System;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form30 : Form
    {
        public Form30()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {
            // 1. Login -> Question
            ucLogin.btTiepTuc.Click += (s, e) => SwitchScreen(ucLogin, ucQuestion);
            ucLogin.btKetThuc.Click += (s, e) => this.Close();

            // 2. Question -> Finish
            ucQuestion.btQuayLai.Click += (s, e) => SwitchScreen(ucQuestion, ucLogin);
            ucQuestion.btNopBai.Click += (s, e) => SwitchScreen(ucQuestion, ucFinish);

            // [QUAN TRỌNG] Bấm Tiếp tục -> Cũng sang Finish luôn (vì chỉ có 1 câu)
            ucQuestion.btTiep.Click += (s, e) => SwitchScreen(ucQuestion, ucFinish);

            // 3. Finish -> Thoát
            ucFinish.btKetThuc.Click += (s, e) => this.Close();
        }

        private void SwitchScreen(UserControl fromUC, UserControl toUC)
        {
            fromUC.Visible = false; // Ẩn cái cũ

            if (!this.Controls.Contains(toUC))
            {
                this.Controls.Add(toUC); // Thêm cái mới nếu chưa có
            }

            toUC.Visible = true; // Hiện cái mới
            toUC.BringToFront(); // Đưa lên trên cùng
        }
    }
}