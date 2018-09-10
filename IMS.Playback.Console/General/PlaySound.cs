using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    public abstract class PlaySound : IDeviceBase {
        private IOutput output;
        public abstract void Play(object data);
    }
}
