using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPKShellIconExt;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace VPKIconExtInstaller
{
    public partial class VPKInstaller : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string path);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);
        public VPKInstaller()
        {
            InitializeComponent();
            string cuname = System.Globalization.CultureInfo.InstalledUICulture.Name;
            if (cuname == "zh-Hans" || cuname == "zh-CN")
            {
                Core.appLanguage = Language.zh_cn;
            }
            else if (cuname == "zh-Hant" || cuname == "zh-TW" || cuname == "zh-HK")
            {
                Core.appLanguage = Language.zh_tw;
            }
            else
            {
                Core.appLanguage = Language.en_us;
            }
            
        }
        private void VPKInstaller_Load(object sender, EventArgs e)
        {
            initLanguage();
#if DEBUG
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Enabled = true;
            this.debugVPKLoaderToolStripMenuItem.Enabled = true;
#endif
        }

        private void initLanguage()
        {
            RefreshLanguage(Core.appLanguage);
        }
        private void RefreshLanguage(Language value)
        {
            this.Invoke(new SetUILanguageDelegate(SetUILanguage), new object[] { value });
        }

        private delegate void SetUILanguageDelegate(Language language);

        private void SetUILanguage(Language language)
        {
            switch (language)
            {
                case Language.en_us:
                    this.buttonInstall.Text = "Install";
                    this.buttonUninstall.Text = "Uninstall";
                    this.aboutToolStripMenuItem.Text = "About";
                    this.aboutThisInstallerToolStripMenuItem.Text = "About this App";
                    this.labelDescription.Text = "This is a simple shell extension for psvita vpk applications.\nIt can show vpk icons in Windows Explorer.\nMake sure you have the.NET framework 4.5 + installed.";

                    break;
                case Language.zh_cn:
                    this.buttonInstall.Text = "安装";
                    this.buttonUninstall.Text = "移除";
                    this.aboutToolStripMenuItem.Text = "关于";
                    this.aboutThisInstallerToolStripMenuItem.Text = "关于本应用";
                    this.labelDescription.Text = "这是一个PSV VPK的windows图标小扩展。\n安装后可以在资源管理器中显示VPK的图标。\n请确认您的电脑安装了.NET framework 4.5或以上版本。";

                    break;
                case Language.zh_tw:
                    this.buttonInstall.Text = "安装";
                    this.buttonUninstall.Text = "移除";
                    this.aboutToolStripMenuItem.Text = "關於";
                    this.aboutThisInstallerToolStripMenuItem.Text = "關於本軟體";
                    this.labelDescription.Text = "這是一個PSV VPK的windows圖標小擴展。\n安裝后可以在Windows 檔案總管中顯示VPK圖標。\n請確認您的電腦安裝了.NET framework 4.5或以上版本。";

                    break;
                default:
                    break;
            }
        }

        private void aboutThisInstallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VPKInstallerAbout form = new VPKInstallerAbout(this.Location.X, this.Location.Y);
            form.Show();
        }

        private void enusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshLanguage(Language.en_us);
        }

        private void 简体中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshLanguage(Language.zh_cn);
        }

        private void 繁体中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshLanguage(Language.zh_tw);
        }

        

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            VPKInstallerAbout form = new VPKInstallerAbout(this.Location.X , this.Location.Y);
            form.Show();
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            InstallCOM();
        }

        private void InstallCOM()
        {

            string WINDIR = System.Environment.GetEnvironmentVariable("windir");
            string FRAMEWORK = @"Microsoft.NET\Framework";
            string FRAMEWORK64 = @"Microsoft.NET\Framework64";
            string DOTNTEVERSION = "v4.0.30319";
            string REGASM = "RegAsm.exe";

            int p = (int)Environment.OSVersion.Platform;
            if (p != 4 && p != 6 && p != 128)
            {
                string path = System.IO.Path.Combine(WINDIR, IntPtr.Size == 8 ? FRAMEWORK64 : FRAMEWORK, DOTNTEVERSION, REGASM);
                Process process = new Process();
                process.StartInfo.WorkingDirectory = System.IO.Path.Combine(WINDIR , IntPtr.Size == 8 ? FRAMEWORK64 : FRAMEWORK, DOTNTEVERSION);
                process.StartInfo.FileName = REGASM;

                process.StartInfo.Arguments = string.Format(@"/codebase {0}\VPKShellIconExt.dll", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
                process.StartInfo.UseShellExecute = true;
                process.Start();
                MessageBox.Show("OK! VPKShellIconExt.dll Installed!\n Please do not delete this installer.");

            }
        }

        private void UninstallCOM()
        {
            string WINDIR = System.Environment.GetEnvironmentVariable("windir");
            string FRAMEWORK = @"Microsoft.NET\Framework";
            string FRAMEWORK64 = @"Microsoft.NET\Framework64";
            string DOTNTEVERSION = "v4.0.30319";
            string REGASM = "RegAsm.exe";

            int p = (int)Environment.OSVersion.Platform;
            if (p != 4 && p != 6 && p != 128)
            {
                string path = System.IO.Path.Combine(WINDIR, IntPtr.Size == 8 ? FRAMEWORK64 : FRAMEWORK, DOTNTEVERSION, REGASM);
                Process process = new Process();
                process.StartInfo.WorkingDirectory = System.IO.Path.Combine(WINDIR, IntPtr.Size == 8 ? FRAMEWORK64 : FRAMEWORK, DOTNTEVERSION);
                process.StartInfo.FileName = REGASM;
                process.StartInfo.Arguments = string.Format(@"/unregister {0}\VPKShellIconExt.dll", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
                process.StartInfo.UseShellExecute = true;

                process.Start();
                MessageBox.Show("Extension Uninstalled!\n The VPKShellIconExt.dll will be unloaded on next restart.");

            }
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            UninstallCOM();
        }

        private void debugVPKLoaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugVPKLoader();
        }

        private void DebugVPKLoader()
        {
            VPKLoader loader = new VPKLoader();
            loader.LoadVPK("VitaShell.vpk");
            MessageBox.Show(string.Format("{0}:\nVPK STATE:{1}", loader.FileName , loader.Type.ToString()));
        }

        private void debugVPKSFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamForm form = new ParamForm("VitaShell.vpk");
            form.Show();
        }
    }
}
