using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public class OledScreen : ScreenBase {
        public OledScreen() {
            Manufacturer = "Samsung";
            ManufactureDate = DateTime.Today;
        }

        public override string ToString() {
            return "Oled Screen";
        }
    }

}
