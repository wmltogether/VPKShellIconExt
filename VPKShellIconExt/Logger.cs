using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
/// <summary>
/// Thanks:
/// >SharpShell : https://github.com/dwmkerr/sharpshell
/// >DotNetZip : http://dotnetzip.codeplex.com/
/// </summary>
namespace VPKShellIconExt
{
    public static class Logger
    {
        public static void Log(string title, string message)
        {
#if DEBUG
            string date;
            date = "[" + System.DateTime.Now.ToString() + "]";

            SharpShell.Diagnostics.Logging.Log(string.Format("{0},{1},{2}", date, title, message));
            System.Diagnostics.Debug.Print(string.Format("{0},{1},{2}", date, title, message));
#endif
        }

        public static void Error(string title, string message)
        {
#if DEBUG
            string date;
            date = "[" + System.DateTime.Now.ToString() + "]";

            SharpShell.Diagnostics.Logging.Error(string.Format("{0},{1},{2}", date, title, message));
            System.Diagnostics.Debug.Print(string.Format("{0},{1},{2}", date, title, message));
#endif
        }
    }

    

}
