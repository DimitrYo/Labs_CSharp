namespace IMS.SMS.Charger.GUI {
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
