using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMS.SMS.Charger.GUI {

    public enum BatteryMethod {
        Tasks,
        Threads,
        ThreadTimer
    }

    public interface IBatteryChange : IDisposable {
        int BatteryChangeValue { get; set; }

        void Start();
        void Stop();
        event Action<int> BatteryChange;
    }

    class BatteryChangeThread : IBatteryChange {
        public int BatteryChangeValue { get; set; }
        public event Action<int> BatteryChange;

        public void Dispose() {
            throw new NotImplementedException();
        }

        public void Start() {
            throw new NotImplementedException();
        }

        public void Stop() {
            throw new NotImplementedException();
        }
    }

    class BatteryChangeTask : IBatteryChange {
        public int BatteryChangeValue { get; set; }
        public event Action<int> BatteryChange;

        public void Dispose() {
            throw new NotImplementedException();
        }

        public void Start() {
            throw new NotImplementedException();
        }

        public void Stop() {
            throw new NotImplementedException();
        }
    }

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
            //GenerateBatteryChangeTimer.Change(Timeout.Infinite, Timeout.Infinite);
            GenerateBatteryChangeTimer.Dispose();
        }

        private void OnBatteryChange(object state) {
            BatteryChange?.BeginInvoke(BatteryChangeValue, null, null);
        }
    }
    public class BatteryFactory {
        public virtual IBatteryChange CreateBatteryChange(BatteryMethod method) {
            IBatteryChange battery = null;

            switch (method) {
                case BatteryMethod.Tasks:
                battery = new BatteryChangeTask();
                break;

                case BatteryMethod.Threads:
                battery = new BatteryChangeThread();
                break;

                case BatteryMethod.ThreadTimer:
                battery = new BatteryChangeThreadTimer();
                break;
            }

            return battery;
        }
    }
}
