using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    public class SamsungHeadset : PlaySound {
        private IOutput output;

        public SamsungHeadset(IOutput output) {
            Manufacturer = "Apple";
            ManufactureDate = DateTime.Today;
            this.output = output;
        }

        public override string ToString() {
            return "Samsung Headset";
        }

        public override void Play(object data) {
            output.WriteLine($"\n{this.GetType().Name} sound");
        }
    }
}
