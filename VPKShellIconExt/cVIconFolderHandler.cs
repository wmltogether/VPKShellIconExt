using System;
using System.Linq;
using System.Runtime.InteropServices;
using SharpShell.SharpIconHandler;
using SharpShell.Attributes;
using System.Drawing;
using SharpShell.Extensions;
using Microsoft.Win32;
using SharpShell.ServerRegistration;
using System.IO;
using SharpShell.Interop;

namespace VPKShellIconExt
{
    [Guid("f148c149-22c1-4098-996d-eb878080650a")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [COMServerAssociation(AssociationType.Directory)]


    public class cVIconFolderHandler : SharpIconHandler
    {
        
        protected override Icon GetIcon(bool smallIcon, uint iconSize)
        {
            Bitmap m_icon = null;
            if (m_icon == null)
            {
                try
                {
                    
                    if (File.Exists(Path.Combine(SelectedItemPath, @"sce_sys\icon0.png")) &&
                        File.Exists(Path.Combine(SelectedItemPath, @"sce_sys\param.sfo")))
                    {
                        m_icon = TextureTool.GetBitmapFromFile(Path.Combine(SelectedItemPath, @"sce_sys\icon0.png"));
                        if (m_icon == null)
                        {
                            Properties.Resources.VPK_ICON0.ToBitmap();
                        }
                        m_icon = TextureTool.MergeTex(m_icon,
                                    Properties.Resources.VPK_SIG_FOLDER,
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    m_icon.Width,
                                    m_icon.Height);
                        GC.Collect();
                        return Icon.FromHandle(TextureTool.ResizeTex(m_icon, new Size((int)iconSize, (int)iconSize)).GetHicon());

                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    //m_icon = Properties.Resources.VPK_ICON0.ToBitmap();
                    Logger.Log(this.ToString(), string.Format("Cant'load icon from {0}", SelectedItemPath));
                    return null;
                }
            }
            return null;
        }

        [CustomRegisterFunction]
        public static void postDoRegister(Type type, RegistrationType registrationType)
        {

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
                Logger.Error("Reg Error"
                     ,e.Message);
            }
        }
    }
    
}
