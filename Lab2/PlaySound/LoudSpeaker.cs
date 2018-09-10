using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    public class LoudSpeaker : PlaySound {
        private IOutput output;

        public LoudSpeaker(IOutput output) {
            Manufacturer = "Meizu";
            ManufactureDate = DateTime.Today;
            this.output = output;
        }

        public override string ToString() {
            return "Phone loud Headset";
        }

        public override void Play(object data) {
            output.WriteLine($"{nameof(PhoneSpeaker)} sound");
        }
    }
}
