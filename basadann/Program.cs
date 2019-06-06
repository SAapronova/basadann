using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basadann
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Zastavka zas = new Zastavka();
            DateTime end = DateTime.Now + TimeSpan.FromSeconds(5);
            zas.Show();
            while (end > DateTime.Now)
            {
                Application.DoEvents();
            }
            zas.Close();
            zas.Dispose();
            Application.Run(new Enter());
        }
    }
}
