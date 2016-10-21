using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace VPKShellIconExt
{
    public class VPKLoader
    {
        //public area
        public Bitmap Icon = null;
        public string FileName = "";
        public string Path = "";
        public string PackageName = "";
        public string Package_APP_VER = "";
        public string Package_CONTENT_ID = "";
        public string Package_PSP2_DISP_VER = "";
        public string Package_PSP2_SYSTEM_VER = "";
        public string Package_STITLE = "";
        public string Package_TITLE = "";
        public string Package_TITLE_ID = "";
        public string Package_VERSION = "";
        public bool isVitaVPK = false;
        public VPKType Type = VPKType.Unknown;

        //private area
        
        private byte[] icon_data;
        private byte[] eboot_data;
        private byte[] param_data;

        //const area
        private const string VPK_icon0 = "sce_sys/icon0.png";
        private const string VPK_param = "sce_sys/param.sfo";
        private const string VPK_eboot = "eboot.bin";
        private const string VPK_mai_prx = "mai_moe/mai.suprx";
        private const string VPK_vitamin_prx = "sce_module/steroid.suprx";

        public void LoadVPK(string filename)
        {
            FileName = filename;
            openZIPStream(FileName);


        }

        public void LoadVPK(Stream fStream)
        {
            openZIPStream(fStream);

        }

        private void openZIPStream(Stream fStream)
        {
            ZipFile zip = ZipFile.Read(fStream);
            this.genZIPStream(zip);
            zip.Dispose();
        }

        private void openZIPStream(string fName)
        {
            ZipFile zip;
            zip = new ZipFile(fName);
            this.genZIPStream(zip);
            zip.Dispose();
        }

        private void genZIPStream(ZipFile zip)
        {
            Stream icon_stream = new MemoryStream();
            Stream param_stream = new MemoryStream();
            Stream eboot_stream = new MemoryStream();

            //Stream stream = new FileStream(fName, FileMode.Open, FileAccess.Read, FileShare.Read);

            isVitaVPK = this.checkVPK(zip);

            if (isVitaVPK)
            {
                ZipEntry icon_entry = zip[VPK_icon0];
                ZipEntry param_entry = zip[VPK_param];
                ZipEntry eboot_entry = zip[VPK_eboot];
                icon_entry.Extract(icon_stream);
                param_entry.Extract(param_stream);
                eboot_entry.Extract(eboot_stream);
                icon_stream.Position = 0;
                param_stream.Position = 0;
                eboot_stream.Position = 0;
                try
                {
                    this.Icon = TextureTool.GetBitmapFromStream(icon_stream);
                    byte[] paramByte = new byte[param_stream.Length];
                    param_stream.Read(paramByte, 0, paramByte.Length);//获取param.sfo
                    param_data = paramByte;
                    byte[] ebootByte = new byte[0x100];
                    eboot_stream.Read(ebootByte, 0, 0x100); //只获取eboot的前0x100字节
                    eboot_data = ebootByte;
                    checkVPKType(zip);
                    checkParamSFO(param_data);

                }
                catch
                {
                    this.Icon = null;


                }

            }
            icon_stream.Close();
            param_stream.Close();
            eboot_stream.Close();
        }
        private bool checkVPK(ZipFile zip)
        {
            if (zip.ContainsEntry(VPK_icon0) && zip.ContainsEntry(VPK_param))
            {
                return true;
            }
            return false;
        }

        private bool checkVPKType(ZipFile zip)
        {
            if (zip.ContainsEntry(VPK_icon0) && zip.ContainsEntry(VPK_param))
            {
                Logger.Log(this.ToString(),
                        string.Format("Got icon entry from vpk:{0}", this.FileName));
                if (zip.ContainsEntry(VPK_eboot))
                {
                    if (checkUnSafeEboot(eboot_data) == false)
                    {
                        Type = VPKType.Danger_VPK;
                        Logger.Log(this.ToString(),
                        string.Format(" vpk:{0} is danger_vpk", this.FileName));
                    }
                    
                    else
                    {
                        Type = VPKType.Normal_VPK;
                        Logger.Log(this.ToString(),
                            string.Format(" vpk:{0} is normal_vpk", this.FileName));
                        if (zip.ContainsEntry(VPK_mai_prx))
                        {
                            Type = VPKType.Mai_VPK;
                            Logger.Log(this.ToString(),
                                string.Format(" vpk:{0} is mai_vpk", this.FileName));
                        }
                        else if (zip.ContainsEntry(VPK_vitamin_prx))
                        {
                            Type = VPKType.Vitamin_VPK;
                            Logger.Log(this.ToString(),
                                string.Format(" vpk:{0} is vitamin_vpk", this.FileName));
                        }

                    }

                }


                return true;
            }
            return false;
        }

        private bool checkUnSafeEboot(byte[] eboot_hdr)
        {
            bool result = false;
            if (eboot_hdr.Length < 0x80)
            {
                result = true;
            }
            else
            {
                if ((int)eboot_hdr[0x80] == 1)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            
            return result;
        }

        private void checkParamSFO(byte[] input)
        {
            SFOReader sfoReader = new SFOReader(input);
            Package_APP_VER = sfoReader.APP_VER;
            Package_CONTENT_ID = sfoReader.CONTENT_ID;
            Package_PSP2_DISP_VER = sfoReader.PSP2_DISP_VER;
            Package_PSP2_SYSTEM_VER = sfoReader.PSP2_SYSTEM_VER;
            Package_STITLE = sfoReader.STITLE;
            Package_TITLE = sfoReader.TITLE;
            Package_TITLE_ID = sfoReader.TITLE_ID;
            Package_VERSION = sfoReader.VERSION;
    }

    }

    public enum VPKType
    {
        Normal_VPK,
        Mai_VPK,
        Vitamin_VPK,
        Danger_VPK,
        Unknown,
    }
}
