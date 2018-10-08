using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI {
    public class CallsStorage : ICallModel {
        List<CallExtended> Calls;
        public object StorageLock { get; set; }

        public void Add(Call call) {
            lock (StorageLock) {
                throw new NotImplementedException();
            }
        }

        public void Remove(Call call) {
            lock (StorageLock) {
                throw new NotImplementedException();
            }
        }

        public void Start() {
            throw new NotImplementedException();
        }

        public void Stop() {
            throw new NotImplementedException();
        }

        public void ViewChanged(CallViewEventArgs e) {
            throw new NotImplementedException();
        }

        public void AttachIModelObserver(ICallModelObserver view) {
            throw new NotImplementedException();
        }

        public bool IsSubscribedAttachIModelObserver() {
            throw new NotImplementedException();
        }
    }
}
