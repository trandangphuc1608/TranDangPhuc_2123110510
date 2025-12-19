namespace TranDangPhuc_2123110510
{
    partial class Form31
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer tmGameLoop;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.Label lblLevel; // [MỚI] Label hiển thị Level
        private System.Windows.Forms.Label lblGameOver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmGameLoop = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLives = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmGameLoop
            // 
            this.tmGameLoop.Interval = 20;
            this.tmGameLoop.Tick += new System.EventHandler(this.tmGameLoop_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(12, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(83, 25);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score: 0";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLevel.ForeColor = System.Drawing.Color.Yellow;
            this.lblLevel.Location = new System.Drawing.Point(250, 9);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(81, 25);
            this.lblLevel.TabIndex = 3;
            this.lblLevel.Text = "Level: 1";
            this.lblLevel.Visible = false; // Chỉ hiện khi chơi
            // 
            // lblLives
            // 
            this.lblLives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLives.AutoSize = true;
            this.lblLives.BackColor = System.Drawing.Color.Transparent;
            this.lblLives.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLives.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblLives.Location = new System.Drawing.Point(480, 9);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(77, 25);
            this.lblLives.TabIndex = 1;
            this.lblLives.Text = "Lives: 3";
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.BackColor = System.Drawing.Color.Transparent;
            this.lblGameOver.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblGameOver.ForeColor = System.Drawing.Color.Red;
            this.lblGameOver.Location = new System.Drawing.Point(180, 250);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(211, 45);
            this.lblGameOver.TabIndex = 2;
            this.lblGameOver.Text = "GAME OVER";
            this.lblGameOver.Visible = false;
            // 
            // Form31
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.lblScore);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form31";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chicken Hunter Advanced";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form31_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form31_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form31_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}