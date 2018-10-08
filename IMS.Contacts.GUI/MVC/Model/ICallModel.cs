using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI {
    public interface ICallModel {

        void Add(Call call);
        void Remove(Call call);
        void Start();
        void Stop();
        void AttachIModelObserver(ICallModelObserver view);
        void ViewChanged(CallViewEventArgs e);
        bool IsSubscribedAttachIModelObserver();
    }
}
