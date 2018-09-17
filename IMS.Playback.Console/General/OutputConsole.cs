using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    public class OutputConsole : IOutput {
        public string TextOutput { get; set; }

        public void Write(string text) {
            Console.Write(text);
        }
        public void WriteLine(string text) {
            Console.WriteLine(text);
        }

    }
}
