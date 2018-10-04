namespace IMS.SMS.Charger.GUI {
    public interface IModelBatteryObserver {
        void BatteryProgressBarUpdate(IBatteryModel model, BatteryModelEventArgs e);
    }
}