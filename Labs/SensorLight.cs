using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public class SensorLight : SensorBase {
        public SensorLight() {
            Manufacturer = "Qualcomm";
            ManufactureDate = DateTime.Today;
        }

        public override string ToString() {
            return "Brigthness Sensor";
        }
    }
}
