namespace TranDangPhuc_2123110510
{
    partial class Form27
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form27));
            tmEgg = new System.Windows.Forms.Timer(components);
            pbEgg = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbEgg).BeginInit();
            SuspendLayout();
            // 
            // tmEgg
            // 
            tmEgg.Interval = 20;
            tmEgg.Tick += TmEgg_Tick;
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
            // Form27
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 769);
            Controls.Add(pbEgg);
            DoubleBuffered = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form27";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Article 26 - Catch Egg (Falling Logic)";
            ((System.ComponentModel.ISupportInitialize)pbEgg).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmEgg;
        private System.Windows.Forms.PictureBox pbEgg;
    }
}