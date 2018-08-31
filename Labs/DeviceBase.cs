using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public abstract class DeviceBase {
        public string Manufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public virtual string Info() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"\tManufacturer: {Manufacturer}");
            descriptionBuilder.AppendLine($"\tManufacture Date: {ManufactureDate}");
            return descriptionBuilder.ToString();
        }
    }
}
