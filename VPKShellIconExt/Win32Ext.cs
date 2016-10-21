using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace VPKShellIconExt
{
    public static class Win32Ext
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)] uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        const int WM_USER = 0x0400;
        public static void RestartShell()
        {
            try
            {
                var ptr = FindWindow("Shell_TrayWnd", null);
                Console.WriteLine("INIT PTR: {0}", ptr.ToInt32());
                PostMessage(ptr, WM_USER + 436, (IntPtr)0, (IntPtr)0);

                do
                {
                    ptr = FindWindow("Shell_TrayWnd", null);
                    Console.WriteLine("PTR: {0}", ptr.ToInt32());

                    if (ptr.ToInt32() == 0)
                    {
                        Console.WriteLine("Success. Breaking out of loop.");
                        break;
                    }

                    Thread.Sleep(1000);
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} {1}", ex.Message, ex.StackTrace);
            }
            Console.WriteLine("Restarting the shell.");
            string explorer = string.Format("{0}\\{1}", Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe");
            Process process = new Process();
            process.StartInfo.FileName = explorer;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }
    }
}
