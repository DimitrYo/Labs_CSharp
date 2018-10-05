using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.SMS.Filter.GUI;

namespace IMS.SMS.Charger.GUI {

    public delegate void ViewBatteryHandler<IView>(IView sender, ViewBatteryEventArgs e);

    public interface IBatteryView {
        event ViewBatteryHandler<IBatteryView> ChangedProgressBar;

        void setChargeController(BatteryController batteryController);
    }

    public class BatteryController : IController {
        IBatteryModel model;
        IBatteryView view;

        public BatteryController(IBatteryView v, IBatteryModel m) {
            view = v;
            model = m;
            view.setChargeController(this);
            model.AttachIModelObserver((IModelBatteryObserver)view);
            view.ChangedProgressBar += new ViewBatteryHandler<IBatteryView>(this.viewChanged);
            Start();
        }

        public void Start() {
            model.Start();
        }

        public void Stop() {
            model.Stop();
        }

        public void viewChanged(IBatteryView v, ViewBatteryEventArgs e) {
            model.ViewChanged(e);
        }
    }
}
