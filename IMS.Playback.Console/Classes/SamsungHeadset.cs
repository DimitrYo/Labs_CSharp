using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.Application {
    public class SamsungHeadset : IPlaySound {
        public void Play(object data) {
            Console.WriteLine($"{nameof(SamsungHeadset)} sound");
        }
    }
}
