using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.Filter.GUI {

    public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

    public interface IView {

        event ViewHandler<IView> changed;
        void setfilterSmsController(IController cont);
    }
}
