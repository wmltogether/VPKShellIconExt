using System;
using System.Linq;
using System.Runtime.InteropServices;
using SharpShell.SharpIconHandler;
using SharpShell.Attributes;
using System.Drawing;
using SharpShell.Extensions;
using Microsoft.Win32;
using SharpShell.ServerRegistration;

namespace VPKShellIconExt
{
    [Guid("fbab2371-38e8-41ca-bd4a-1f86850ccdbd")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".vpk")]

    public class cVIconHandler : SharpIconHandler
    {
        protected override Icon GetIcon(bool smallIcon, uint iconSize)
        {
            Bitmap m_icon = null;
            if (m_icon == null)
            {
                try
                {
                    VPKLoader loader = new VPKLoader();
                    loader.LoadVPK(SelectedItemPath);
                    if (loader.isVitaVPK)
                    {
                        m_icon = loader.Icon;
                        if (m_icon == null)
                        {
                            Properties.Resources.VPK_ICON0.ToBitmap();
                        }

                        switch (loader.Type)
                        {
                            case VPKType.Normal_VPK:
                                m_icon = TextureTool.MergeTex(m_icon,
                                    Properties.Resources.VPK_SIG_NORMAL,
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    m_icon.Width,
                                    m_icon.Height);
                                break;
                            case VPKType.Vitamin_VPK:
                                m_icon = TextureTool.MergeTex(m_icon,
                                    Properties.Resources.VPK_SIG_VITAMIN,
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    m_icon.Width,
                                    m_icon.Height);
                                break;
                            case VPKType.Mai_VPK:
                                m_icon = TextureTool.MergeTex(m_icon,
                                    Properties.Resources.VPK_SIG_MAI,
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    m_icon.Width,
                                    m_icon.Height);
                                break;
                            case VPKType.Danger_VPK:
                                m_icon = TextureTool.MergeTex(m_icon,
                                    Properties.Resources.VPK_SIG_DANGER,
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                    m_icon.Width,
                                    m_icon.Height);
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        return null;
                    }

                }
                catch
                {
                    //m_icon = Properties.Resources.VPK_ICON0.ToBitmap();
                    Logger.Log(this.ToString(), string.Format("Cant'load vpk from {0}", SelectedItemPath));
                    return null;
                }
            }

            return Icon.FromHandle(TextureTool.ResizeTex(m_icon, new Size((int)iconSize, (int)iconSize)).GetHicon());
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
