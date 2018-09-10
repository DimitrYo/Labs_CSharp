using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    public class UnofficialPhoneHeadset : PlaySound {
        public override void Play(object data) {
            Console.WriteLine($"{nameof(UnofficialPhoneHeadset)} sound");
        }
    }
}
