using System;
using System.Runtime.InteropServices;
using SharpShell.Attributes;
using System.Drawing;
using SharpShell.SharpThumbnailHandler;
using Microsoft.Win32;
using SharpShell.Extensions;
using SharpShell.ServerRegistration;
using System.Linq;

namespace VPKShellIconExt
{
    // currently no need to generate thumbails
    /*[Guid("29d76e65-1f7d-4010-92db-991011f52db2")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".vpk")]

    public class cVIconThumbnailHandler : SharpThumbnailHandler
    {
        protected override Bitmap GetThumbnailImage(uint width)
        {
            Bitmap m_icon;
            //  Attempt to open the stream with a reader.
            try
            {
                m_icon = null;
                VPKLoader loader = new VPKLoader();
                loader.LoadVPK(SelectedItemStream);
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
                            m_icon = TextureTool.MergeTex(TextureTool.ResizeTex(m_icon, new Size(128, 128)),
                                Properties.Resources.VPK_SIG_NORMAL,
                                new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                m_icon.Width,
                                m_icon.Height);
                            break;
                        case VPKType.Vitamin_VPK:
                            m_icon = TextureTool.MergeTex(TextureTool.ResizeTex(m_icon, new Size(128, 128)),
                                Properties.Resources.VPK_SIG_VITAMIN,
                                new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                m_icon.Width,
                                m_icon.Height);
                            break;
                        case VPKType.Mai_VPK:
                            m_icon = TextureTool.MergeTex(TextureTool.ResizeTex(m_icon, new Size(128, 128)),
                                Properties.Resources.VPK_SIG_MAI,
                                new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                m_icon.Width,
                                m_icon.Height);
                            break;
                        case VPKType.Danger_VPK:
                            m_icon = TextureTool.MergeTex(TextureTool.ResizeTex(m_icon, new Size(128, 128)),
                                Properties.Resources.VPK_SIG_DANGER,
                                new Rectangle((int)(m_icon.Width * 0.05), 0, (int)(m_icon.Width * 0.95), (int)(m_icon.Height * 0.95)),
                                new Rectangle((int)(m_icon.Width * 0), 0, (int)(m_icon.Width * 1), (int)(m_icon.Height * 1)),
                                m_icon.Width,
                                m_icon.Height);
                            break;
                        default:
                            break;
                    }


                }
                return TextureTool.ResizeTex(m_icon, new Size((int)width, (int)width));
            }
            catch (Exception exception)
            {
                //  Log the exception and return null for failure.
                LogError("An exception occured opening the vpk file.", exception);
                return null;
            }
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
                     , e.Message);
            }
        }
    }*/
}
