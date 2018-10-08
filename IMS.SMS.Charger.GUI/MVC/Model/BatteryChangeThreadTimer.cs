using System;
using System.Threading;

namespace IMS.SMS.Charger.GUI {
    class BatteryChangeThreadTimer : IBatteryChange {
        public int BatteryChangeValue { get; set; }
        public int TimeoutSeconds { get; set; }
        public event Action<int> BatteryChange;

        private Timer GenerateBatteryChangeTimer;

        public BatteryChangeThreadTimer() {
            this.BatteryChangeValue = 2;
            this.TimeoutSeconds = 1;
        }

        public void Dispose() {
            GenerateBatteryChangeTimer?.Dispose();
        }

        public void Start() {
            GenerateBatteryChangeTimer = new Timer(OnBatteryChange, null, 0, TimeoutSeconds * 1000);
        }

        public void Stop() {
            GenerateBatteryChangeTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void OnBatteryChange(object state) {
            BatteryChange?.BeginInvoke(BatteryChangeValue, null, null);
        }
    }
}
