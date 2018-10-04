using IMS.SMS.GUI;

namespace IMS.SMS.Charger.GUI {

    public delegate void BatteryModelHandler<IBatteryModel>(IBatteryModel sender, BatteryModelEventArgs e);

    public interface IBatteryModel {
        void OnBatteryLevelChange(int level);
        void Start();
        void Stop();
        void AttachIModelObserver(IModelBatteryObserver view);
        void ViewChanged(ViewBatteryEventArgs e);
    }
}