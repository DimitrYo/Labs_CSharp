using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.SMS.Filter.GUI {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new SmsFilter();
            var mdl = new SmsStorage();
            var cnt = new Controllet(view, mdl);
            cnt.StartTimer();

            Application.Run(view);
        }
    }
}
