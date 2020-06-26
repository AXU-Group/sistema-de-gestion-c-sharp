using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace SG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool mutexCreado = false;
            Mutex miMutex = new Mutex(true, "Vizsla", out mutexCreado);
            if (mutexCreado)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MDIParentPadre());
                miMutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Vizsla ya se encuentra abierto.","ATENCION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
    }
}
