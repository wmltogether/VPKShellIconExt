using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System.Linq;
using SharpShell.ServerRegistration;
using Microsoft.Win32;
using SharpShell.Extensions;

namespace VPKShellIconExt
{
    [Guid("68439d8f-5b38-4337-9f9a-0d6fd8680f0a")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".vpk")]
    public class cVIconContextMenu : SharpContextMenu
    {
        
        /// <summary>
        /// 检查何时显示ContextMenu菜单，return true时永远显示。
        /// </summary>
        /// <returns></returns>
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override System.Windows.Forms.ContextMenuStrip CreateMenu()
        {
            var mainMenu = new ContextMenuStrip();
            var itemExt = new ToolStripMenuItem
            {
                Text = "VPK Shell Ext..",
                Image = TextureTool.ResizeTex(Properties.Resources.VPK_ICON_CONTEXT.ToBitmap(), new System.Drawing.Size(mainMenu.Height + 1, mainMenu.Height + 1))
            };

            #region show settings
            var settingsMenu = new ToolStripMenuItem
            {
                Text = "Settings",
                Image = TextureTool.ResizeTex(Properties.Resources.VPK_ICON_CONTEXT.ToBitmap(), new System.Drawing.Size(mainMenu.Height + 1 , mainMenu.Height + 1))
            };
            var paramMenu = new ToolStripMenuItem
            {
                Text = "Show param.sfo Info",
                Image = TextureTool.ResizeTex(Properties.Resources.VPK_ICON_CONTEXT.ToBitmap(), new System.Drawing.Size(mainMenu.Height + 1, mainMenu.Height + 1))
            };

            settingsMenu.Click += (sender, args) => showSettingsWindow();
            paramMenu.Click += (sender, args) => showParamWindow();
            itemExt.DropDownItems.Add(settingsMenu);
            itemExt.DropDownItems.Add(paramMenu);
            #endregion
            mainMenu.Items.Add(itemExt);
            return mainMenu;

        }

        private void showSettingsWindow()
        {
            SettingsForm settingsForm = new SettingsForm(SelectedItemPaths.ElementAt(0));
            settingsForm.ShowDialog();
        }
        private void showParamWindow()
        {
            ParamForm settingsForm = new ParamForm(SelectedItemPaths.ElementAt(0));
            settingsForm.ShowDialog();
        }

        [CustomRegisterFunction]
        public static void postDoRegister(Type type, RegistrationType registrationType)
        {
            Console.WriteLine("Registering " + type.FullName);

            #region Clean up older versions registry
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"\CLSID\" +
                    type.GUID.ToRegistryString() + @"\InprocServer32"))
                {
                    if (key != null && key.GetSubKeyNames().Count() != 0)
                    {
                        Console.WriteLine("Found old version in registry, cleaning up ...");
                        foreach (var k in key.GetSubKeyNames())
                        {
                            if (k != type.Assembly.GetName().Version.ToString())
                            {
                                Registry.ClassesRoot.DeleteSubKeyTree(@"\CLSID\" +
                        type.GUID.ToRegistryString() + @"\InprocServer32\" + k);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error("Error ",
                     e.Message);
            }
            #endregion
        }

    }
}
