using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI {
    public class CallController : IController {
        ICallView view;
        ICallModel model;

        public CallController(ICallView v, ICallModel m) {
            view = v;
            model = m;
            view.setCallController(this);
            model.AttachIModelObserver((ICallModelObserver)view);
            view.Changed += new CallViewHandler<ICallView>(this.viewChanged);
            Start();
        }

        public void Start() {
            model.Start();
        }

        public void Stop() {
            model.Stop();
        }
        public void viewChanged(ICallView v, CallViewEventArgs e) {
            model.ViewChanged(e);
        }
    }
}
