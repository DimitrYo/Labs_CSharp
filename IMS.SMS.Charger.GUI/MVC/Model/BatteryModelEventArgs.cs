using System;

namespace IMS.SMS.Charger.GUI {
    public class BatteryModelEventArgs : EventArgs {
        public int ChargeLevelInt { get; set; }
        public bool IsCharging { get; set; }
    }
}