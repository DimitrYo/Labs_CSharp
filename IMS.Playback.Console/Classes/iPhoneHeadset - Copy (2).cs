using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.Application {
    public class iPhoneHeadset : IPlaySound {
        public void Play(object data) {
            Console.WriteLine($"{nameof(iPhoneHeadset)} sound");
        }
    }
}
