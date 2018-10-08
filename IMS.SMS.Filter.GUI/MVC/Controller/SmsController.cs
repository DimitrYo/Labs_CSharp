namespace IMS.SMS.Filter.GUI {
    public class SmsController : IController {
        IView view;
        IModel model;

        public SmsController(IView v,IModel m) {
            view = v;
            model = m;
            view.setfilterSmsController(this);
            model.AttachIModelObserver((IModelObserver)view);
            view.Changed += new ViewSmsHandler<IView>(this.viewChanged);
            Start();
        }

        public void Start() {
            model.Start();
        }

        public void Stop() {
            model.Stop();
        }
        public void viewChanged(IView v, ViewEventArgs e) {
            model.ViewChanged(e);
        }
    }
}
