using System;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    public partial class Form25 : Form
    {
        private int second = 0;

        public Form25()
        {
            InitializeComponent();
        }

        private void BtStart_Click(object sender, EventArgs e)
        {
            // Reset Interval (phòng trường hợp Designer chưa set)
            tmStopwatch.Interval = 1000;
            tmStopwatch.Start();
        }

        private void BtStop_Click(object sender, EventArgs e)
        {
            tmStopwatch.Stop();
        }

        private void TmStopwatch_Tick(object sender, EventArgs e)
        {
            second++;

            // Format mm:ss cho đẹp
            TimeSpan time = TimeSpan.FromSeconds(second);
            lblDisplay.Text = time.ToString(@"mm\:ss");
        }
    }
}