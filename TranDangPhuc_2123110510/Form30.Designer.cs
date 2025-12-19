namespace TranDangPhuc_2123110510
{
    partial class Form30
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ucLogin = new TranDangPhuc_2123110510.Login();
            this.ucQuestion = new TranDangPhuc_2123110510.Question();
            this.ucFinish = new TranDangPhuc_2123110510.Finish();
            this.SuspendLayout();
            // 
            // ucLogin
            // 
            // [SỬA QUAN TRỌNG] Dùng Dock = Fill để lấp đầy 100% không chừa viền
            this.ucLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogin.Location = new System.Drawing.Point(0, 0);
            this.ucLogin.Name = "ucLogin";
            this.ucLogin.Size = new System.Drawing.Size(700, 500); // Size ảo, Dock sẽ tự chỉnh lại
            this.ucLogin.TabIndex = 0;
            // 
            // ucQuestion
            // 
            this.ucQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucQuestion.Location = new System.Drawing.Point(0, 0);
            this.ucQuestion.Name = "ucQuestion";
            this.ucQuestion.Size = new System.Drawing.Size(700, 500);
            this.ucQuestion.TabIndex = 1;
            // 
            // ucFinish
            // 
            this.ucFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFinish.Location = new System.Drawing.Point(0, 0);
            this.ucFinish.Name = "ucFinish";
            this.ucFinish.Size = new System.Drawing.Size(700, 500);
            this.ucFinish.TabIndex = 2;
            // 
            // Form30
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // Kích thước Form to đẹp
            this.ClientSize = new System.Drawing.Size(700, 500);

            // Add ucLogin vào
            this.Controls.Add(this.ucLogin);

            this.Name = "Form30";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình thi trắc nghiệm";
            this.ResumeLayout(false);

        }

        #endregion

        private Login ucLogin;
        private Question ucQuestion;
        private Finish ucFinish;
    }
}