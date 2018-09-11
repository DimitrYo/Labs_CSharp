using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.GUI {
    public class PhoneSpeaker : PlaySound {
        private IOutput output;

        public PhoneSpeaker(IOutput output) {
            Manufacturer = "Meizu";
            ManufactureDate = DateTime.Today;
            this.output = output;
        }

        public override string ToString() {
            return "Phone standart speaker";
        }

        public override void Play(object data) {
            output.WriteLine($"{nameof(PhoneSpeaker)} sound");
        }
    }
}
