using System;

namespace IMS.SMS.Charger.GUI {
    public class BatteryModelEventArgs : EventArgs {
        public int ChargeLevelInt { get; set; }
        public int ChargeStatus { get; set; }
        public ChargeLevels ChargeLevel { get; set; }
    }
}