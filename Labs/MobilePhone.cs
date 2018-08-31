using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public class MobilePhone : DeviceBase {
        private List<DeviceBase> Devices;
        public string Model { get; set; }

        public MobilePhone() {
            this.Manufacturer = "Meizu";
            Model = "M2";

            Devices = new List<DeviceBase>();
            var screen = new OledScreen();
            var sensor1 = new SensorGyroscope();
            var sensor2 = new SensorLight();

            Devices.Add(screen);
            Devices.Add(sensor1);
            Devices.Add(sensor2);

        }

        public override string Info() {
            var text = "Phone information:\r\n";
            text += $"\tModel: {Model}\r\n";
            text += base.Info();

            return text;
        }

        public string GetFullDescription() {
            var text = Info();

            Devices.ForEach(delegate (DeviceBase device) {
                text += device.Info();
            });

            return text;
        }
    }
}
