using System;
using System.Threading;

namespace IMS.SMS.Charger.GUI {
    class BatteryChangeThread : IBatteryChange {
        public int BatteryChangeValue { get; set; }
        public event Action<int> BatteryChange;
        public int TimeoutSeconds { get; set; }

        CancellationTokenSource cts;
        private Thread thread;

        public BatteryChangeThread() {
            this.BatteryChangeValue = 2;
            this.TimeoutSeconds = 1;
        }

        public void Dispose() {
            thread?.Abort();
        }

        public void Start() {
            cts = new CancellationTokenSource();
            thread = new Thread(new ParameterizedThreadStart(threadRun));
            thread.Start(cts.Token);
        }

        public void Stop() {
            cts.Cancel();
            cts?.Dispose();
        }

        private void threadRun(object obj) {
            CancellationToken ct = (CancellationToken)obj;
            while (!ct.IsCancellationRequested) {
                Thread.Sleep(TimeSpan.FromSeconds(TimeoutSeconds));
                BatteryChange?.BeginInvoke(BatteryChangeValue, null, null);
            }
        }

        private void OnBatteryChange() {
            BatteryChange?.BeginInvoke(BatteryChangeValue, null, null);
        }
    }
}
