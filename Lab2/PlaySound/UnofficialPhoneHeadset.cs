using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.GUI {
    public class UnofficialPhoneHeadset : PlaySound {
        private IOutput output;

        public UnofficialPhoneHeadset(IOutput output) {
            Manufacturer = "Apple";
            ManufactureDate = DateTime.Today;
            this.output = output;
        }

        public override string ToString() {
            return "Unofficial Phone Headset";
        }

        public override void Play(object data) {
            output.WriteLine($"{nameof(UnofficialPhoneHeadset)} sound");
        }
    }
}
