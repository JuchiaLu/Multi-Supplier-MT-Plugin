using System;
using System.Windows.Forms;

namespace MT_SDK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Kilgray.Utils.Log.Initialize("", "");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
