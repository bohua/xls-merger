using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JCodesRegLib;

namespace XlsMerger
{
    static class Program
    {
        public enum SystemRegistryStatus { NotRegisted, Registed, TrialWithDayLimit, TrialWithFuncLimit };

        static public RegClass registry;
        static public SystemRegistryStatus systemRegistryStatus = Program.SystemRegistryStatus.NotRegisted;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            WelcomeForm welcome = new WelcomeForm();
            welcome.Show();

            registry = new RegClass(-1, "XlsMerger");

            if (!Program.registry.hasRegisted())
            {
                welcome.Close();
                new RegistryForm().ShowDialog();
            }
            else {
                Program.systemRegistryStatus = Program.SystemRegistryStatus.Registed;
            }

            Application.Run(new MainWindow(welcome));
        }
    }
}
