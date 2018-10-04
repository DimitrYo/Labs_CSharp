namespace IMS.SMS.Filter.GUI {
    public class Controllet : IController {
        IView view;
        IModel model;

        public Controllet(IView v,IModel m) {
            view = v;
            model = m;
            view.setController(this);
            model.AttachIModelObserver((IModelObserver)view);
            view.changed += new ViewHandler<IView>(this.viewChanged);
            StartTimer();
        }

        public void StartTimer() {
            model.StartTimer();
        }

        public void StopTimer() {
            model.StopTimer();
        }
        public void viewChanged(IView v, ViewEventArgs e) {
            model.ViewChanged(e);
        }
    }
}
