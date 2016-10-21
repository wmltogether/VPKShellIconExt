using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VPKShellIconExt
{
    public partial class SettingsForm : Form
    {
        
        public SettingsForm(string vpkPath)
        {
            InitializeComponent();
            this.Text = "VPK Icon Ext Settings";
        }

        private void buttonRefreshCache_Click(object sender, EventArgs e)
        {
            //force refresh icon cache
            SharpShell.Interop.Shell32.SHChangeNotify(0x08000000, 0, IntPtr.Zero, IntPtr.Zero);

        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.labelAbout.Text = "Simple VPK icon extension.\nCopyright (c) 2016 wmltogether ";
        }
    }
}
