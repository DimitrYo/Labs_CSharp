using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI.MVC.Model {
    public class CallGenerator {

        public int TimeoutSeconds { get; set; }
        //public delegate void NewCallDelegate();
        //public event NewCallDelegate NewCall;

        public event Action<Call> NewCall;

        private Timer GenerateCallTimer;
        public CallFactory callFactory { get; set; }

        public CallGenerator() {
            callFactory = new CallFactory();
            this.TimeoutSeconds = 1;
        }

        public void Dispose() {
            GenerateCallTimer?.Dispose();
        }

        public void Start() {
            GenerateCallTimer = new Timer(OnNewCall, null, 0, TimeoutSeconds * 1000);
        }

        public void Stop() {
            GenerateCallTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void OnNewCall(object state) {
            
            Call call = callFactory.CreateNew();
            NewCall?.BeginInvoke(call, null, null);
        }

        public bool HasSubscribers() {
            return NewCall != null;
        }
    }

    public class CallFactory {
        public static int CallNumber { get; private set; }
        internal Call CreateNew() {
            CallNumber += 1;

            return new Call {

            };
        }
    }
}


