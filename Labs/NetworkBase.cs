using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class NetworkBase : DeviceBase {
        public override string Info() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Network adapter type: {this.ToString()}");
            var text = descriptionBuilder.ToString();
            text += base.Info();
            return text;
        }
    }
}
