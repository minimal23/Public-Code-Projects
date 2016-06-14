using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace dxLoop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 mainForm = new Form1();
            Application.Exit();
        }
    }
}
