using System;
using System.Linq;
using System.Runtime.InteropServices;
using SharpShell.SharpIconHandler;
using SharpShell.Attributes;
using System.Drawing;
using SharpShell.Extensions;
using Microsoft.Win32;
using SharpShell.ServerRegistration;
using SharpShell.SharpInfoTipHandler;
using System.IO;

namespace VPKShellIconExt
{
    [Guid("694bd18c-1ee1-4302-b55b-9bc83d916658")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [COMServerAssociation(AssociationType.Directory)]
    public class cVIconFolderInfoTipHandler : SharpInfoTipHandler
    {
        protected override string GetInfo(RequestedInfoType infoType, bool singleLine)
        {
            switch (infoType)
            {
                case RequestedInfoType.InfoTip:
                    if (File.Exists(Path.Combine(SelectedItemPath , @"sce_sys\param.sfo")) && File.Exists(Path.Combine(SelectedItemPath, @"sce_sys\icon0.png")))
                    {
                        try
                        {
                            byte[] sfodata = File.ReadAllBytes(Path.Combine(SelectedItemPath, @"sce_sys\param.sfo"));
                            SFOReader sfoReader = new SFOReader(sfodata);
                            string result = string.Format("PSVita Game Folder\nTITLE:{0}\nTITLE_ID:{1}\nCONTENT_ID:{2}\nPSP2_DISP_VER:{3}\nVERSION:{4}",
                                                    sfoReader.TITLE,
                                                    sfoReader.TITLE_ID,
                                                    sfoReader.CONTENT_ID,
                                                    sfoReader.PSP2_DISP_VER,
                                                    sfoReader.VERSION);

                            sfodata = null;
                            GC.Collect();
                            return result;
                        }
                        catch
                        {
                            Logger.Error("SFO Reading Error", string.Format("Error occured in reading {0}", Path.Combine(SelectedItemPath, @"sce_sys\param.sfo")));
                            return string.Empty;
                        }
                    }
                    DirectoryInfo info = new DirectoryInfo(SelectedItemPath);
                    return string.Format("{0}\n{1}", Path.GetFileName(SelectedItemPath) ,Directory.GetCreationTime(SelectedItemPath));
                case RequestedInfoType.Name:
                    return string.Format("Folder '{0}'", Path.GetFileName(SelectedItemPath));
                default:
                    return string.Empty;

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
    }
    
}
