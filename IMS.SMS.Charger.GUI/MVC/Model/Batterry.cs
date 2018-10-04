using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.Charger.GUI {

    public enum ChargeLevels { Low, Medium, High };
    public class Batterry : IBatteryModel {

        public event BatteryModelHandler<Batterry> changed;

        public int ChargeLevelInt { get; set; }
        public int ChargeStatus { get; set; }
        public ChargeLevels ChargeLevel { get; set; }

        public void AttachIModelObserver(IModelBatteryObserver view) {
            changed += new BatteryModelHandler<Batterry>(view.BatteryProgressbarUpdate);
        }

        public void OnBatteryLevelChange(int level) {
            throw new NotImplementedException();
        }

        public void Start() {
            throw new NotImplementedException();
        }

        public void Stop() {
            throw new NotImplementedException();
        }

        public void ViewChanged(ViewBatteryEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
