using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using phongtro.GUI;
using phongtro.HeThongGiaoDien;

namespace phongtro
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dang_Nhap_NT());
        }
    }
}
