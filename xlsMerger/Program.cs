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
        static public string workingPath = System.IO.Directory.GetCurrentDirectory();
        static public string metaFile = workingPath + @"\meta.data";
        static public string tmpFile = workingPath + @"\tmp.data";
        static public string tmpRukuFile = workingPath + @"\tmpRuku.data";

        static public string printTemplateRuku = workingPath + @"\Resources\printTemplateRuku.tpl.xls";
        static public string printTemplateChuku = workingPath + @"\Resources\printTemplateChuku.tpl";

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

            /*
            Ruku rk = new Ruku();
            rk.rk_dh = "1";
            RukuSheet ruku = new RukuSheet();
            ruku.Push(rk);
            ruku.filePath = "a.file";
            List<RukuSheet> list = new List<RukuSheet>();
            RukuSheetWriter w = new RukuSheetWriter();
            w.saveToFile(list);
            w.loadFromFile();
            */

            Application.Run(new MainWindow(welcome));
        }
    }
}
