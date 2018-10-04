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
