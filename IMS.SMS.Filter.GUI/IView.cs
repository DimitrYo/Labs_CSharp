using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.Filter.GUI {
    public interface IView {
        event ViewHandler<IView> changed;
        void setController(IController cont);
    }
}
