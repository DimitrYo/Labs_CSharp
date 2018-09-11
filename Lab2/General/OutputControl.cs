using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.GUI {
    public class OutputControl : IOutput {

        public string TextOutput { get; set; }
        public void Write(string text) {
            TextOutput += text;
        }

        public void WriteLine(string text) {
            TextOutput += text + Environment.NewLine;
        }
    }

}

