namespace TranDangPhuc_2123110510
{
    partial class Login
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
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.tbPob = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbExam = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbExam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btTiepTuc = new System.Windows.Forms.Button();
            this.btKetThuc = new System.Windows.Forms.Button();
            this.gbInfo.SuspendLayout();
            this.gbExam.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.cbSex);
            this.gbInfo.Controls.Add(this.dtpDob);
            this.gbInfo.Controls.Add(this.tbPob);
            this.gbInfo.Controls.Add(this.tbName);
            this.gbInfo.Controls.Add(this.tbId);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfo.Location = new System.Drawing.Point(20, 15);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(660, 260);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Thông tin thí sinh";
            // 
            // cbSex
            // 
            this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.cbSex.Location = new System.Drawing.Point(150, 200);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(120, 24);
            this.cbSex.TabIndex = 9;
            // 
            // dtpDob
            // 
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(150, 115);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(180, 23);
            this.dtpDob.TabIndex = 8;
            // 
            // tbPob
            // 
            this.tbPob.Location = new System.Drawing.Point(150, 157);
            this.tbPob.Name = "tbPob";
            this.tbPob.Size = new System.Drawing.Size(350, 23);
            this.tbPob.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(150, 72);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(350, 23);
            this.tbName.TabIndex = 6;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(150, 32);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(180, 23);
            this.tbId.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giới tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nơi sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày sinh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã:";
            // 
            // gbExam
            // 
            this.gbExam.Controls.Add(this.label8);
            this.gbExam.Controls.Add(this.label7);
            this.gbExam.Controls.Add(this.cbExam);
            this.gbExam.Controls.Add(this.label6);
            this.gbExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbExam.Location = new System.Drawing.Point(20, 290);
            this.gbExam.Name = "gbExam";
            this.gbExam.Size = new System.Drawing.Size(660, 100);
            this.gbExam.TabIndex = 1;
            this.gbExam.TabStop = false;
            this.gbExam.Text = "Thông tin kỳ thi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(530, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Thời gian: 120";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(410, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Số câu hỏi: 60";
            // 
            // cbExam
            // 
            this.cbExam.FormattingEnabled = true;
            this.cbExam.Location = new System.Drawing.Point(150, 37);
            this.cbExam.Name = "cbExam";
            this.cbExam.Size = new System.Drawing.Size(240, 24);
            this.cbExam.TabIndex = 1;
            this.cbExam.Text = "Chứng chỉ tin học A tiếng Anh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Danh sách kỳ thi:";
            // 
            // btTiepTuc
            // 
            this.btTiepTuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTiepTuc.Location = new System.Drawing.Point(420, 405);
            this.btTiepTuc.Name = "btTiepTuc";
            this.btTiepTuc.Size = new System.Drawing.Size(120, 40);
            this.btTiepTuc.TabIndex = 2;
            this.btTiepTuc.Text = "Tiếp tục";
            this.btTiepTuc.UseVisualStyleBackColor = true;
            // 
            // btKetThuc
            // 
            this.btKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btKetThuc.Location = new System.Drawing.Point(560, 405);
            this.btKetThuc.Name = "btKetThuc";
            this.btKetThuc.Size = new System.Drawing.Size(120, 40);
            this.btKetThuc.TabIndex = 3;
            this.btKetThuc.Text = "Kết thúc";
            this.btKetThuc.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btKetThuc);
            this.Controls.Add(this.btTiepTuc);
            this.Controls.Add(this.gbExam);
            this.Controls.Add(this.gbInfo);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(700, 460);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbExam.ResumeLayout(false);
            this.gbExam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPob;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.GroupBox gbExam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbExam;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btTiepTuc;
        public System.Windows.Forms.Button btKetThuc;
    }
}