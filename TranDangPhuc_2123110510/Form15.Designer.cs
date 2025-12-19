namespace TranDangPhuc_2123110510
{
    partial class Form15
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbName = new System.Windows.Forms.TextBox();
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.rbNam = new System.Windows.Forms.RadioButton();
            this.rbNu = new System.Windows.Forms.RadioButton();
            this.cbDiscount = new System.Windows.Forms.CheckBox();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btTinhTien = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.gbGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(100, 27);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(250, 25);
            this.tbName.TabIndex = 0;
            this.tbName.Text = "Nguyễn Văn A";
            // 
            // gbGender
            // 
            this.gbGender.Controls.Add(this.rbNam);
            this.gbGender.Controls.Add(this.rbNu);
            this.gbGender.Location = new System.Drawing.Point(30, 70);
            this.gbGender.Name = "gbGender";
            this.gbGender.Size = new System.Drawing.Size(320, 80);
            this.gbGender.TabIndex = 1;
            this.gbGender.TabStop = false;
            this.gbGender.Text = "Giới tính";
            // 
            // rbNam
            // 
            this.rbNam.AutoSize = true;
            this.rbNam.Checked = true;
            this.rbNam.Location = new System.Drawing.Point(50, 30);
            this.rbNam.Name = "rbNam";
            this.rbNam.Size = new System.Drawing.Size(56, 23);
            this.rbNam.TabIndex = 0;
            this.rbNam.TabStop = true;
            this.rbNam.Text = "Nam";
            this.rbNam.UseVisualStyleBackColor = true;
            // 
            // rbNu
            // 
            this.rbNu.AutoSize = true;
            this.rbNu.Location = new System.Drawing.Point(180, 30);
            this.rbNu.Name = "rbNu";
            this.rbNu.Size = new System.Drawing.Size(45, 23);
            this.rbNu.TabIndex = 1;
            this.rbNu.Text = "Nữ";
            this.rbNu.UseVisualStyleBackColor = true;
            // 
            // cbDiscount
            // 
            this.cbDiscount.AutoSize = true;
            this.cbDiscount.Location = new System.Drawing.Point(30, 170);
            this.cbDiscount.Name = "cbDiscount";
            this.cbDiscount.Size = new System.Drawing.Size(109, 23);
            this.cbDiscount.TabIndex = 2;
            this.cbDiscount.Text = "Giảm giá (%)";
            this.cbDiscount.UseVisualStyleBackColor = true;
            this.cbDiscount.CheckedChanged += new System.EventHandler(this.CbDiscount_CheckedChanged);
            // 
            // tbDiscount
            // 
            this.tbDiscount.Enabled = false;
            this.tbDiscount.Location = new System.Drawing.Point(160, 167);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(100, 25);
            this.tbDiscount.TabIndex = 3;
            this.tbDiscount.Text = "0";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(30, 220);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(320, 100);
            this.tbResult.TabIndex = 4;
            // 
            // btTinhTien
            // 
            this.btTinhTien.Location = new System.Drawing.Point(130, 340);
            this.btTinhTien.Name = "btTinhTien";
            this.btTinhTien.Size = new System.Drawing.Size(100, 40);
            this.btTinhTien.TabIndex = 5;
            this.btTinhTien.Text = "Tính tiền";
            this.btTinhTien.UseVisualStyleBackColor = true;
            this.btTinhTien.Click += new System.EventHandler(this.BtTinhTien_Click);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(250, 340);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(100, 40);
            this.btThoat.TabIndex = 6;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.BtThoat_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 19);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Họ tên:";
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 480);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btTinhTien);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.cbDiscount);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.tbName);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Article 14 - RadioButton & CheckBox";
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox gbGender;
        private System.Windows.Forms.RadioButton rbNam;
        private System.Windows.Forms.RadioButton rbNu;
        private System.Windows.Forms.CheckBox cbDiscount;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btTinhTien;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Label lblName;
    }
}