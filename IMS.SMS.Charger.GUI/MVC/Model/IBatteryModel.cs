using IMS.SMS.GUI;

namespace IMS.SMS.Charger.GUI {

    public delegate void BatteryModelHandler<IBatteryModel>(IBatteryModel sender, BatteryModelEventArgs e);

    public interface IBatteryModel {
        void OnBatteryConsuming(int level);
        void Start();
        void Stop();
        void AttachIModelObserver(IModelBatteryObserver view);

        void AttachCharger();
        void DettachCharger();
        void ViewChanged(ViewBatteryEventArgs e);

        void UpdateView();
        bool IsSubscribedAttachIModelObserver();

        BatteryMethod BatteryMethod { get; set; }
        IBatteryChange BatteryConsuming { get; set; }


    }
}