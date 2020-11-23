using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revisione
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Controller.trovoRevisioniRecenti(Controller.getFolderFile(@"C:\Users\edgesuser\Desktop\testOld"), Controller.getFolderFile(@"C:\Users\edgesuser\Desktop\testNew"));

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
