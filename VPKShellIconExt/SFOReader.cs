using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPKShellIconExt
{
    public class SFOReader
    {
        
        public string APP_VER = "";
        public string CONTENT_ID = "";
        public string PSP2_DISP_VER = "";
        public string PSP2_SYSTEM_VER = "";
        public string STITLE = "";
        public string TITLE = "";
        public string TITLE_ID = "";
        public string VERSION = "";

        public SFOReader(byte[] input)
        {
            using (var br = new BinaryReader(new MemoryStream(input)))
            {
                SFOHeader header = new SFOHeader(br);
                if (header.Magic != 0x46535000)
                {
                    this.TITLE = "ERROR SFO" + header.Magic.ToString();
                    return;
                }
                Dictionary<string, string> dict = new Dictionary<string, string>();
                for (int i = 0; i < header.nums; i++)
                {
                    try
                    {
                        Table table = new Table();
                        int pos = 0x14 + 0x10 * i;
                        table.Read(br, pos, header.KeyTableOffset, header.ValueTableOffset);
                        dict.Add(table.key, table.value);
                    }
                    catch
                    {

                    }
                }
                if (dict.ContainsKey("APP_VER"))
                {
                    APP_VER = dict["APP_VER"];
                }
                if (dict.ContainsKey("CONTENT_ID"))
                {
                    CONTENT_ID = dict["CONTENT_ID"];
                }
                if (dict.ContainsKey("PSP2_DISP_VER"))
                {
                    PSP2_DISP_VER = dict["PSP2_DISP_VER"];
                }
                if (dict.ContainsKey("PSP2_SYSTEM_VER"))
                {
                    PSP2_SYSTEM_VER = dict["PSP2_SYSTEM_VER"];
                }
                if (dict.ContainsKey("STITLE"))
                {
                    STITLE = dict["STITLE"];
                }
                if (dict.ContainsKey("TITLE"))
                {
                    TITLE = dict["TITLE"];
                }
                if (dict.ContainsKey("TITLE_ID"))
                {
                    TITLE_ID = dict["TITLE_ID"];
                }
                if (dict.ContainsKey("VERSION"))
                {
                    VERSION = dict["VERSION"];
                }
            }
        }

    }

    public class SFOHeader
    {
        public UInt32 Magic; //\x00PSF
        public int Version;
        public int KeyTableOffset;
        public int ValueTableOffset;
        public int nums;

        public SFOHeader(BinaryReader br)
        {
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            Magic = br.ReadUInt32();
            Version = br.ReadInt32();
            KeyTableOffset = br.ReadInt32();
            ValueTableOffset = br.ReadInt32();
            nums = br.ReadInt32();

        }
    }

    public class Table
    {
        public int key_offset;
        public int value_offset;
        public string key;
        public string value;
        public int fmt;
        public int length;
        public int max_length;

        public void Read(BinaryReader br, int pos, int KeyTableOffset, int ValueTableOffset)
        {
            br.BaseStream.Seek(pos, SeekOrigin.Begin);

            key_offset = br.ReadInt16() + KeyTableOffset;
            fmt = br.ReadInt16();
            length = br.ReadInt32();
            max_length = br.ReadInt32();
            value_offset = br.ReadInt32() + ValueTableOffset;

            br.BaseStream.Seek(key_offset, SeekOrigin.Begin);
            //key
            key = Encoding.ASCII.GetString(br.ReadBytes(0x20)).Split('\0')[0];

            br.BaseStream.Seek(value_offset, SeekOrigin.Begin);
            
            //value
            switch (fmt)
            {
                case 0x0204:
                    //utf-8
                    value = Encoding.UTF8.GetString(br.ReadBytes((int)length)).Replace("\0", "");
                    break;
                case 0x0404:
                    //integer
                    value = br.ReadUInt32().ToString();
                    break;
                case 0x0004:
                    //ascii
                    value = Encoding.ASCII.GetString(br.ReadBytes((int)length)).Replace("\0", "");
                    break;
                default:
                    value = "";
                    break;
            }
        }
    }

}
