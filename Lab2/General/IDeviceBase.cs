using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback.GUI {
    public abstract class IDeviceBase {
        public string Manufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public virtual string Info() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"\tManufacturer: {Manufacturer}");
            descriptionBuilder.AppendLine($"\tManufacture Date: {ManufactureDate}");
            descriptionBuilder.AppendLine($"\tDevice Type : {this.GetType().Name}");
            return descriptionBuilder.ToString();
        }

       
    }
}
