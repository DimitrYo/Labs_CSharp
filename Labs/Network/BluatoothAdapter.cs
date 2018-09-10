using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Phone {
    class BluatoothAdapter : NetworkBase {
        public BluatoothAdapter() {
            Manufacturer = "Qualcomm";
            ManufactureDate = DateTime.Today;
        }

        public override string ToString() {
            return "Bluetooth adapter";
        }
    }
}
