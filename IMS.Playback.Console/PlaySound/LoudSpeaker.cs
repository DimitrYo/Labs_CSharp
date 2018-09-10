using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    public class LoudSpeaker : PlaySound {
        public override void Play(object data) {
            Console.WriteLine($"{nameof(LoudSpeaker)} sound");
        }
    }
}
