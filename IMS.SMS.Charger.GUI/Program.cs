using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.SMS.Filter.GUI;

namespace IMS.SMS.Charger.GUI {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new Charger();
            var mdl = new SmsStorage();
            var cnt = new SmsController(view, mdl);

            var bmdl = new Battery(BatteryMethod.ThreadTimer);
            var bcnt = new BatteryController(view,bmdl);

            Application.Run(view);
        }
    }
}
