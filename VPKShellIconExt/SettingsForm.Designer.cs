namespace VPKShellIconExt
{
    partial class SettingsForm
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
            this.buttonRefreshCache = new System.Windows.Forms.Button();
            this.labelRefreshHelp = new System.Windows.Forms.Label();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAbout = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRefreshCache
            // 
            this.buttonRefreshCache.Location = new System.Drawing.Point(12, 129);
            this.buttonRefreshCache.Name = "buttonRefreshCache";
            this.buttonRefreshCache.Size = new System.Drawing.Size(259, 23);
            this.buttonRefreshCache.TabIndex = 0;
            this.buttonRefreshCache.Text = "Refresh Cache";
            this.buttonRefreshCache.UseVisualStyleBackColor = true;
            this.buttonRefreshCache.Click += new System.EventHandler(this.buttonRefreshCache_Click);
            // 
            // labelRefreshHelp
            // 
            this.labelRefreshHelp.AutoSize = true;
            this.labelRefreshHelp.Location = new System.Drawing.Point(11, 165);
            this.labelRefreshHelp.Name = "labelRefreshHelp";
            this.labelRefreshHelp.Size = new System.Drawing.Size(191, 12);
            this.labelRefreshHelp.TabIndex = 1;
            this.labelRefreshHelp.Text = "This will Restart explorer.exe.";
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(12, 202);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(258, 23);
            this.buttonAbout.TabIndex = 2;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "About This Extension.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VPKShellIconExt.Properties.Resources.AppIcon;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labelAbout
            // 
            this.labelAbout.Location = new System.Drawing.Point(120, 13);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(152, 98);
            this.labelAbout.TabIndex = 5;
            this.labelAbout.Text = "Simple VPK icon Extension";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(13, 256);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 12);
            this.labelVersion.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 278);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.labelRefreshHelp);
            this.Controls.Add(this.buttonRefreshCache);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRefreshCache;
        private System.Windows.Forms.Label labelRefreshHelp;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.Label labelVersion;
    }
}