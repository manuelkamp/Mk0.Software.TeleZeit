using Mk0.Tools.SingleInstance;
using System;
using System.Windows.Forms;

namespace Mk0.Software.TeleZeit
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleApplication.Run(new TeleZeit());
        }
    }
}
