using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.GUI {
    public abstract class PlaySound : IDeviceBase {
        public abstract void Play(object data);
    }
}
