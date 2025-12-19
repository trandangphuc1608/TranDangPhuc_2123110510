namespace TranDangPhuc_2123110510
{
    partial class Form29
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
            this.components = new System.ComponentModel.Container();
            this.lblScore = new System.Windows.Forms.Label();
            this.tmEgg = new System.Windows.Forms.Timer(this.components);
            this.tmChicken = new System.Windows.Forms.Timer(this.components);
            this.pbEgg = new System.Windows.Forms.PictureBox();
            this.pbChicken = new System.Windows.Forms.PictureBox();
            this.pbBasket = new System.Windows.Forms.PictureBox();
            this.btReplay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbEgg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChicken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.Red;
            this.lblScore.Location = new System.Drawing.Point(650, 500);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(111, 29);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score: 0";
            // 
            // tmEgg
            // 
            this.tmEgg.Interval = 30;
            this.tmEgg.Tick += new System.EventHandler(this.TmEgg_Tick);
            // 
            // tmChicken
            // 
            this.tmChicken.Interval = 20;
            this.tmChicken.Tick += new System.EventHandler(this.TmChicken_Tick);
            // 
            // pbEgg
            // 
            this.pbEgg.BackColor = System.Drawing.Color.Transparent;
            this.pbEgg.Location = new System.Drawing.Point(300, 10);
            this.pbEgg.Name = "pbEgg";
            this.pbEgg.Size = new System.Drawing.Size(30, 40);
            this.pbEgg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEgg.TabIndex = 1;
            this.pbEgg.TabStop = false;
            // 
            // pbChicken
            // 
            this.pbChicken.BackColor = System.Drawing.Color.Transparent;
            this.pbChicken.Location = new System.Drawing.Point(300, 10);
            this.pbChicken.Name = "pbChicken";
            this.pbChicken.Size = new System.Drawing.Size(100, 100);
            this.pbChicken.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChicken.TabIndex = 2;
            this.pbChicken.TabStop = false;
            // 
            // pbBasket
            // 
            this.pbBasket.BackColor = System.Drawing.Color.Transparent;
            this.pbBasket.Location = new System.Drawing.Point(300, 480);
            this.pbBasket.Name = "pbBasket";
            this.pbBasket.Size = new System.Drawing.Size(120, 80);
            this.pbBasket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBasket.TabIndex = 3;
            this.pbBasket.TabStop = false;
            // 
            // btReplay
            // 
            this.btReplay.BackColor = System.Drawing.Color.OrangeRed;
            this.btReplay.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btReplay.ForeColor = System.Drawing.Color.White;
            this.btReplay.Location = new System.Drawing.Point(325, 275);
            this.btReplay.Name = "btReplay";
            this.btReplay.Size = new System.Drawing.Size(150, 50);
            this.btReplay.TabIndex = 4;
            this.btReplay.Text = "CHƠI LẠI";
            this.btReplay.UseVisualStyleBackColor = false;
            this.btReplay.Visible = false;
            this.btReplay.Click += new System.EventHandler(this.BtReplay_Click);
            // 
            // Form29
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btReplay);
            this.Controls.Add(this.pbBasket);
            this.Controls.Add(this.pbChicken);
            this.Controls.Add(this.pbEgg);
            this.Controls.Add(this.lblScore);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form29";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Hứng Trứng (Full Version)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form29_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbEgg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChicken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer tmEgg;
        private System.Windows.Forms.Timer tmChicken;
        private System.Windows.Forms.PictureBox pbEgg;
        private System.Windows.Forms.PictureBox pbChicken;
        private System.Windows.Forms.PictureBox pbBasket;
        private System.Windows.Forms.Button btReplay;
    }
}