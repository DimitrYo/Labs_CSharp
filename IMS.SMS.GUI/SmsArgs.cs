using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.GUI {
    public class SmsArgs : EventArgs {
        public SmsArgs(string message) {
            Message = message;
        }

        public string Message { get; set; }
    }
}
