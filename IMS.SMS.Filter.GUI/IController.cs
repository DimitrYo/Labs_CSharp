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

        public Controllet(IView v, IModel m) {
            view = v;
            model = m;
            view.setController(this);
            model.attachIModelObserver((IModelObserver)view);
            //view.changed += new ViewHandler<IView>(this.view_changed);
        }

        public void StartTimer() {
            model.StartTimer();
        }

        public void StopTimer() {
            model.StopTimer();
        }
    }
}
