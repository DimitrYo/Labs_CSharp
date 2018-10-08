using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI {


    public delegate void CallViewHandler<ICallView>(ICallView sender, CallViewEventArgs e);
    public interface ICallView {
        event CallViewHandler<ICallView> Changed;
        void setCallController(IController cont);
    }
}
    
    