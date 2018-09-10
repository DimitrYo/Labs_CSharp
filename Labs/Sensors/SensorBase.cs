using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Phone {
    public class SensorBase : DeviceBase {
        public override string Info() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Sencor Type: {this.ToString()}");
            var text = descriptionBuilder.ToString();
            text += base.Info();
            return text;
        }
    }
}
