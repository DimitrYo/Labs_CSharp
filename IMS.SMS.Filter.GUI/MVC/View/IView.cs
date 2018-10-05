using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.Filter.GUI {

    public delegate void ViewSmsHandler<IView>(IView sender, ViewEventArgs e);

    public interface IView {

        event ViewSmsHandler<IView> Changed;
        void setfilterSmsController(IController cont);
    }
}
