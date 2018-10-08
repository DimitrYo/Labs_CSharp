using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMS.SMS.Charger.GUI {
    class BatteryChangeTask : IBatteryChange {
        public int BatteryChangeValue { get; set; }
        public int TimeoutSeconds { get; set; }
        private Task task;
        private CancellationTokenSource source;

        public event Action<int> BatteryChange;

        public BatteryChangeTask() {
            this.BatteryChangeValue = 2;
            this.TimeoutSeconds = 1;
        }

        public void Dispose() {
            task?.Wait();
            task?.Dispose();
        }

        public void Start() {
            source = new CancellationTokenSource();
            task = Task.Factory.StartNew(async delegate () {
                while (true) {
                    await Task.Delay(TimeSpan.FromSeconds(TimeoutSeconds), source.Token);
                    BatteryChange?.BeginInvoke(BatteryChangeValue, null, null);
                }
            });
        }

        public void Stop() {
            source.Cancel();
        }

        public bool HasSubscribers() {
            return BatteryChange != null;
        }
    }
}
