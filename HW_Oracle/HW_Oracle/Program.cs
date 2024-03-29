﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Oracle
{
    static class Program
    {
        // 外部函数声明
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string name);
        // 这个函数只能接受ASCII，所以一定要设置CharSet = CharSet.Ansi，不然会失败
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(IntPtr hmod, string name);
        private delegate void FarProc();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // SetProcessDPIAware是Vista以上才有的函数，需兼容XP的话不能直接调用，需按如下所示间接调用
            IntPtr hUser32 = GetModuleHandle("user32.dll");
            IntPtr addrSetProcessDPIAware = GetProcAddress(hUser32, "SetProcessDPIAware");
            if (addrSetProcessDPIAware != IntPtr.Zero)
            {
                FarProc SetProcessDPIAware = (FarProc)Marshal.GetDelegateForFunctionPointer(addrSetProcessDPIAware, typeof(FarProc));
                SetProcessDPIAware();
            }
            // C#的原有代码
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
