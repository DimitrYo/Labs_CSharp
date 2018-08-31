using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
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
