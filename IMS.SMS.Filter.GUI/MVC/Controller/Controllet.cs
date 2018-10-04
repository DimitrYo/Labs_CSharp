namespace IMS.SMS.Filter.GUI {
    public class Controllet : IController {
        IView view;
        IModel model;

        public Controllet(IView v,IModel m) {
            view = v;
            model = m;
            view.setfilterSmsController(this);
            model.AttachIModelObserver((IModelObserver)view);
            view.changed += new ViewHandler<IView>(this.viewChanged);
            StartTimer();
        }

        public void StartTimer() {
            model.Start();
        }

        public void StopTimer() {
            model.Stop();
        }
        public void viewChanged(IView v, ViewEventArgs e) {
            model.ViewChanged(e);
        }
    }
}
