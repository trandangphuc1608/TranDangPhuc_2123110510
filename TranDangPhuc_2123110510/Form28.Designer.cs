namespace TranDangPhuc_2123110510 // <-- Đảm bảo dòng này giống hệt bên Form28.cs
{
    partial class Form28
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form28));
            tmGame = new System.Windows.Forms.Timer(components);
            pbEgg = new PictureBox();
            pbBasket = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbEgg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBasket).BeginInit();
            SuspendLayout();
            // 
            // tmGame
            // 
            tmGame.Interval = 20;
            tmGame.Tick += TmGame_Tick;
            // 
            // pbEgg
            // 
            pbEgg.BackColor = Color.Transparent;
            pbEgg.Image = (Image)resources.GetObject("pbEgg.Image");
            pbEgg.Location = new Point(400, 0);
            pbEgg.Margin = new Padding(4, 5, 4, 5);
            pbEgg.Name = "pbEgg";
            pbEgg.Size = new Size(67, 108);
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.TabIndex = 0;
            pbEgg.TabStop = false;
            // 
            // pbBasket
            // 
            pbBasket.BackColor = Color.Transparent;
            pbBasket.Image = (Image)resources.GetObject("pbBasket.Image");
            pbBasket.Location = new Point(400, 769);
            pbBasket.Margin = new Padding(4, 5, 4, 5);
            pbBasket.Name = "pbBasket";
            pbBasket.Size = new Size(133, 154);
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.TabIndex = 1;
            pbBasket.TabStop = false;
            // 
            // Form28
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1067, 923);
            Controls.Add(pbBasket);
            Controls.Add(pbEgg);
            DoubleBuffered = true;
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form28";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Article 27 - Catch Egg Game (Move Basket)";
            KeyDown += Form28_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbEgg).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBasket).EndInit();
            ResumeLayout(false);

        }

        #endregion

        // ĐÂY LÀ PHẦN QUAN TRỌNG MÀ MÁY BẠN ĐANG BÁO LỖI THIẾU
        // Hãy chắc chắn các dòng này tồn tại:
        private System.Windows.Forms.Timer tmGame;
        private System.Windows.Forms.PictureBox pbEgg;
        private System.Windows.Forms.PictureBox pbBasket;
    }
}