using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPKShellIconExt
{
    public partial class ParamForm : Form
    {
        private string path;
        public ParamForm(string vpk_path)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            path = vpk_path;
        }

        private void ParamForm_Load(object sender, EventArgs e)
        {
        VPKLoader vpkLoader = new VPKLoader();
            vpkLoader.LoadVPK(path);
            this.textBoxSFOInfo.Lines = new string[]
            {
                string.Format("{0}:    {1}","Content ID  ", vpkLoader.Package_CONTENT_ID),
                string.Format("{0}:    {1}","STITLE      ", vpkLoader.Package_STITLE),
                string.Format("{0}:    {1}","TITLE       ", vpkLoader.Package_TITLE),
                string.Format("{0}:    {1}","TITLE ID    ", vpkLoader.Package_TITLE_ID),
                string.Format("{0}:    {1}","DISP VER    ", vpkLoader.Package_PSP2_DISP_VER),
                string.Format("{0}:    {1}","SYSTEM VER  ", vpkLoader.Package_PSP2_SYSTEM_VER),
                string.Format("{0}:    {1}","VERSION     ", vpkLoader.Package_VERSION),
                string.Format("{0}:    {1}","APP VER     ", vpkLoader.Package_APP_VER)
            };
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
