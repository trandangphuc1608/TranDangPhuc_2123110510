namespace TranDangPhuc_2123110510
{
    partial class Question
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDob = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.gbQ = new System.Windows.Forms.GroupBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.gbA = new System.Windows.Forms.GroupBox();
            this.rbD = new System.Windows.Forms.RadioButton();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.btQuayLai = new System.Windows.Forms.Button();
            this.btTiep = new System.Windows.Forms.Button();
            this.btNopBai = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.gbQ.SuspendLayout();
            this.gbA.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblDob);
            this.pnlTop.Controls.Add(this.lblName);
            this.pnlTop.Controls.Add(this.lblId);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(700, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDob.Location = new System.Drawing.Point(520, 22);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(135, 15);
            this.lblDob.TabIndex = 2;
            this.lblDob.Text = "Ngày sinh: 10/10/1994";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(220, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(147, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên: Nguyễn Anh Tú";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblId.Location = new System.Drawing.Point(50, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(46, 19);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Mã: 1";
            // 
            // gbQ
            // 
            this.gbQ.Controls.Add(this.lblQuestion);
            this.gbQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbQ.Location = new System.Drawing.Point(20, 80);
            this.gbQ.Name = "gbQ";
            this.gbQ.Size = new System.Drawing.Size(660, 110);
            this.gbQ.TabIndex = 1;
            this.gbQ.TabStop = false;
            this.gbQ.Text = "Câu hỏi";
            // 
            // lblQuestion
            // 
            this.lblQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(3, 19);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Padding = new System.Windows.Forms.Padding(10);
            this.lblQuestion.Size = new System.Drawing.Size(654, 88);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Một cộng một bằng bao nhiêu?";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbA
            // 
            this.gbA.Controls.Add(this.rbD);
            this.gbA.Controls.Add(this.rbC);
            this.gbA.Controls.Add(this.rbB);
            this.gbA.Controls.Add(this.rbA);
            this.gbA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbA.Location = new System.Drawing.Point(20, 210);
            this.gbA.Name = "gbA";
            this.gbA.Size = new System.Drawing.Size(660, 180);
            this.gbA.TabIndex = 2;
            this.gbA.TabStop = false;
            this.gbA.Text = "Câu trả lời";
            // 
            // rbD
            // 
            this.rbD.AutoSize = true;
            this.rbD.Location = new System.Drawing.Point(50, 145);
            this.rbD.Name = "rbD";
            this.rbD.Size = new System.Drawing.Size(43, 21);
            this.rbD.TabIndex = 3;
            this.rbD.TabStop = true;
            this.rbD.Text = "Ba";
            this.rbD.UseVisualStyleBackColor = true;
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Location = new System.Drawing.Point(50, 107);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(55, 21);
            this.rbC.TabIndex = 2;
            this.rbC.TabStop = true;
            this.rbC.Text = "Năm";
            this.rbC.UseVisualStyleBackColor = true;
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(50, 69);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(51, 21);
            this.rbB.TabIndex = 1;
            this.rbB.TabStop = true;
            this.rbB.Text = "Bốn";
            this.rbB.UseVisualStyleBackColor = true;
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Checked = true;
            this.rbA.Location = new System.Drawing.Point(50, 31);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(47, 21);
            this.rbA.TabIndex = 0;
            this.rbA.TabStop = true;
            this.rbA.Text = "Hai";
            this.rbA.UseVisualStyleBackColor = true;
            // 
            // btQuayLai
            // 
            this.btQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btQuayLai.Location = new System.Drawing.Point(280, 405);
            this.btQuayLai.Name = "btQuayLai";
            this.btQuayLai.Size = new System.Drawing.Size(120, 40);
            this.btQuayLai.TabIndex = 3;
            this.btQuayLai.Text = "Quay lại";
            this.btQuayLai.UseVisualStyleBackColor = true;
            // 
            // btTiep
            // 
            this.btTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btTiep.Location = new System.Drawing.Point(420, 405);
            this.btTiep.Name = "btTiep";
            this.btTiep.Size = new System.Drawing.Size(120, 40);
            this.btTiep.TabIndex = 4;
            this.btTiep.Text = "Tiếp tục";
            this.btTiep.UseVisualStyleBackColor = true;
            // 
            // btNopBai
            // 
            this.btNopBai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btNopBai.Location = new System.Drawing.Point(560, 405);
            this.btNopBai.Name = "btNopBai";
            this.btNopBai.Size = new System.Drawing.Size(120, 40);
            this.btNopBai.TabIndex = 5;
            this.btNopBai.Text = "Nộp bài";
            this.btNopBai.UseVisualStyleBackColor = true;
            // 
            // Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btNopBai);
            this.Controls.Add(this.btTiep);
            this.Controls.Add(this.btQuayLai);
            this.Controls.Add(this.gbA);
            this.Controls.Add(this.gbQ);
            this.Controls.Add(this.pnlTop);
            this.Name = "Question";
            this.Size = new System.Drawing.Size(700, 460);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.gbQ.ResumeLayout(false);
            this.gbA.ResumeLayout(false);
            this.gbA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.GroupBox gbQ;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.GroupBox gbA;
        private System.Windows.Forms.RadioButton rbD;
        private System.Windows.Forms.RadioButton rbC;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.RadioButton rbA;
        public System.Windows.Forms.Button btQuayLai;
        public System.Windows.Forms.Button btNopBai;
        public System.Windows.Forms.Button btTiep;
    }
}