using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public class SensorGyroscope : SensorBase {
        public SensorGyroscope() {
            Manufacturer = "TSMC";
            ManufactureDate = DateTime.Today;
        }

        public override string ToString() {
            return "Gyroscope Sensor";
        }
    }
}