using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.GUI {
    public class iPhoneHeadset : PlaySound {
        private IOutput output;

        public iPhoneHeadset(IOutput output) {
            Manufacturer = "Apple";
            ManufactureDate = DateTime.Today;
            this.output = output;
        }

        public override string ToString() {
            return "IPhone Headset";
        }

        public override void Play(object data) {
            output.WriteLine($"{nameof(iPhoneHeadset)} sound");
        }
    }
}

