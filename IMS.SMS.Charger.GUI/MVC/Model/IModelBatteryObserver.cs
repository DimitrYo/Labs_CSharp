namespace IMS.SMS.Charger.GUI {
    public interface IModelBatteryObserver {
        void BatteryProgressbarUpdate(IBatteryModel model, BatteryModelEventArgs e);
    }
}