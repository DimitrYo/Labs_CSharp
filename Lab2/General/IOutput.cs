using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.GUI {
    public interface IOutput {
        string TextOutput { get; set;}
        void Write(string text);
        void WriteLine(string text);
    }
}
