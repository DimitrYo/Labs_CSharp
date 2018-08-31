using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class LteAdapter : NetworkBase {
        public LteAdapter() {
            Manufacturer = "Huawei";
            ManufactureDate = DateTime.Today;
        }

        public override string ToString() {
            return "LTE Cat 16 adapter";
        }
    }
}
