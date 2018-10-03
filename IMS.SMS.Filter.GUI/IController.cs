using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.Filter.GUI {
    public interface IController {
        void StartTimer();
        void StopTimer();
    }
    public class Controllet : IController {
        IView view;
        IModel model;

        public Controllet(IView v,IModel m) {
            view = v;
            model = m;
            view.setController(this);
            model.attachIModelObserver((IModelObserver)view);
            view.changed += new ViewHandler<IView>(this.viewChanged);
        }

        public void StartTimer() {
            model.StartTimer();
        }

        public void StopTimer() {
            model.StopTimer();
        }
        public void viewChanged(IView v, ViewEventArgs e) {
            model.viewChanged(e);
        }
    }
}
