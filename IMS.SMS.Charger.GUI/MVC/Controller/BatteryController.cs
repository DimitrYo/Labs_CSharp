using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.SMS.Filter.GUI;

namespace IMS.SMS.Charger.GUI {

    public delegate void ViewBatteryHandler<IView>(IView sender, ViewBatteryEventArgs e);

    public interface IBatteryView {

        event ViewBatteryHandler<IBatteryView> changedProgressBar;
        void setfilterSmsController(IController cont); 
    }

    public class BatteryController : IController {
        IBatteryModel model;
        IBatteryView view;

        public BatteryController(IBatteryView v, IBatteryModel m) {
            view = v;
            model = m;
            view.setfilterSmsController(this);
            model.AttachIModelObserver((IModelBatteryObserver)view);
            view.changedProgressBar += new ViewBatteryHandler<IBatteryView>(this.viewChanged);
            StartTimer();
        }

        public void StartTimer() {
            model.Start();
        }

        public void StopTimer() {
            model.Stop();
        }
        public void viewChanged(IBatteryView v, ViewBatteryEventArgs e) {
            model.ViewChanged(e);
        }
    }
}
