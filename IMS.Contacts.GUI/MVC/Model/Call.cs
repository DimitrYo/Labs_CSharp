using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI {
    public class Call : IComparable {
        public string PhoneNumber { get; set; }
        public bool IsIncomingCall { get; set; }
        public DateTime Time { get; set; }

        public int CompareTo(object obj) {
            var call = (Call)obj;
            return this.Time > call.Time ? 1 : -1;
        }
    }
}
