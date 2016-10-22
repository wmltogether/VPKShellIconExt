namespace VPKIconExtInstaller
{
    partial class VPKInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VPKInstaller));
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonUninstall = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutThisInstallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.简体中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.繁体中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugVPKLoaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugVPKSFOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(12, 53);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(223, 72);
            this.buttonInstall.TabIndex = 0;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonUninstall
            // 
            this.buttonUninstall.Location = new System.Drawing.Point(285, 53);
            this.buttonUninstall.Name = "buttonUninstall";
            this.buttonUninstall.Size = new System.Drawing.Size(223, 72);
            this.buttonUninstall.TabIndex = 1;
            this.buttonUninstall.Text = "Uninstall";
            this.buttonUninstall.UseVisualStyleBackColor = true;
            this.buttonUninstall.Click += new System.EventHandler(this.buttonUninstall_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(476, 226);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(32, 23);
            this.buttonHelp.TabIndex = 2;
            this.buttonHelp.Text = " ? ";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutThisInstallerToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutThisInstallerToolStripMenuItem
            // 
            this.aboutThisInstallerToolStripMenuItem.Name = "aboutThisInstallerToolStripMenuItem";
            this.aboutThisInstallerToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aboutThisInstallerToolStripMenuItem.Text = "About This Installer";
            this.aboutThisInstallerToolStripMenuItem.Click += new System.EventHandler(this.aboutThisInstallerToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enusToolStripMenuItem,
            this.简体中文ToolStripMenuItem,
            this.繁体中文ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // enusToolStripMenuItem
            // 
            this.enusToolStripMenuItem.Name = "enusToolStripMenuItem";
            this.enusToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.enusToolStripMenuItem.Text = "English";
            this.enusToolStripMenuItem.Click += new System.EventHandler(this.enusToolStripMenuItem_Click);
            // 
            // 简体中文ToolStripMenuItem
            // 
            this.简体中文ToolStripMenuItem.Name = "简体中文ToolStripMenuItem";
            this.简体中文ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.简体中文ToolStripMenuItem.Text = "简体中文";
            this.简体中文ToolStripMenuItem.Click += new System.EventHandler(this.简体中文ToolStripMenuItem_Click);
            // 
            // 繁体中文ToolStripMenuItem
            // 
            this.繁体中文ToolStripMenuItem.Name = "繁体中文ToolStripMenuItem";
            this.繁体中文ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.繁体中文ToolStripMenuItem.Text = "繁体中文";
            this.繁体中文ToolStripMenuItem.Click += new System.EventHandler(this.繁体中文ToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugVPKLoaderToolStripMenuItem,
            this.debugVPKSFOToolStripMenuItem});
            this.debugToolStripMenuItem.Enabled = false;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(24, 21);
            this.debugToolStripMenuItem.Text = " ";
            // 
            // debugVPKLoaderToolStripMenuItem
            // 
            this.debugVPKLoaderToolStripMenuItem.Enabled = false;
            this.debugVPKLoaderToolStripMenuItem.Name = "debugVPKLoaderToolStripMenuItem";
            this.debugVPKLoaderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.debugVPKLoaderToolStripMenuItem.Text = "Debug VPK Loader";
            this.debugVPKLoaderToolStripMenuItem.Click += new System.EventHandler(this.debugVPKLoaderToolStripMenuItem_Click);
            // 
            // debugVPKSFOToolStripMenuItem
            // 
            this.debugVPKSFOToolStripMenuItem.Name = "debugVPKSFOToolStripMenuItem";
            this.debugVPKSFOToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.debugVPKSFOToolStripMenuItem.Text = "Debug VPK SFO";
            this.debugVPKSFOToolStripMenuItem.Click += new System.EventHandler(this.debugVPKSFOToolStripMenuItem_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(13, 159);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(209, 12);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "VPK Icon Shell Extension Installer";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(12, 237);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(11, 12);
            this.labelVersion.TabIndex = 5;
            this.labelVersion.Text = " ";
            // 
            // VPKInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 261);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonUninstall);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VPKInstaller";
            this.Text = "VPK Icon Ext Installer";
            this.Load += new System.EventHandler(this.VPKInstaller_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonUninstall;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutThisInstallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 简体中文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 繁体中文ToolStripMenuItem;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugVPKLoaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugVPKSFOToolStripMenuItem;
        private System.Windows.Forms.Label labelVersion;
    }
}

