using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.Charger.GUI {

    public class Battery : IBatteryModel, IDisposable {

        public event BatteryModelHandler<Battery> Changed;

        public int ChargeLevel { get; set; }
        public int ChargeStatus { get; set; }
        public bool IsCharging { get; set; }
        public BatteryMethod BatteryMethod { get; set; }
        public IBatteryChange BatteryConsuming { get; set; }
        public IBatteryChange BatteryCharger { get; set; }

        private BatteryFactory Factory;

        public object ChargeLevelLock;

        public Battery(BatteryMethod batteryMethod) {
            this.ChargeLevel = 100;
            ChargeLevelLock = new object();

            Factory = new BatteryFactory();
            this.BatteryMethod = batteryMethod;

            this.BatteryConsuming = Factory.CreateBatteryChange(this.BatteryMethod);
            BatteryConsuming.BatteryChange += OnBatteryConsuming;
        }

        public void AttachIModelObserver(IModelBatteryObserver view) {
            Changed += new BatteryModelHandler<Battery>(view.BatteryProgressBarUpdate);
        }

        public void OnBatteryConsuming(int level) {
            lock (ChargeLevelLock) {
                ChargeLevel = Math.Max(ChargeLevel - level, 0);
            }
            UpdateView(false);
        }

        public void OnBatteryCharger(int level) {
            lock (ChargeLevelLock) {
                ChargeLevel = Math.Min(ChargeLevel + level, 100);
            }
            UpdateView(true);
        }

        public void Start() {
            BatteryConsuming.Start();
        }

        public void Stop() {
            BatteryConsuming.Stop();
        }

        public void UpdateView(bool charger) {
            if ((IsCharging && charger) || (!IsCharging)) {
                var arg = new BatteryModelEventArgs {
                    ChargeLevelInt = this.ChargeLevel,
                    IsCharging = this.IsCharging,
                };
                Changed?.BeginInvoke(this, arg, null, null);
            }
        }

        public void ViewChanged(ViewBatteryEventArgs e) {
            IsCharging = e.IsCharging;

            if (e.IsCharging) {              
                AttachCharger();
            } else {
                if (BatteryCharger != null) {
                    DettachCharger();
                }
            }
        }

        public void Dispose() {
            BatteryConsuming.BatteryChange -= OnBatteryConsuming;
            BatteryConsuming?.Dispose();
            DettachCharger();
        }

        public bool IsSubscribedAttachIModelObserver() {
            return Changed.GetInvocationList().Count() > 0;
        }

        public void AttachCharger() {
            BatteryCharger = Factory.CreateBatteryChange(BatteryMethod);
            BatteryCharger.BatteryChangeValue = 10;
            BatteryCharger.BatteryChange += OnBatteryCharger;
            BatteryCharger.Start();
        }

        public void DettachCharger() {
            if (BatteryCharger?.HasSubscribers() ?? false) {
                BatteryCharger.BatteryChange -= OnBatteryCharger;
            }
            
            BatteryCharger?.Dispose();
        }
    }
}
