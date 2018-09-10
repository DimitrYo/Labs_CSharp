using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Phone {
    public abstract class ScreenBase : DeviceBase {
        public override string  Info() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Screen Type: {this.ToString()}");
            var text = descriptionBuilder.ToString();
            text += base.Info();
            return text;
        }
    }
}
