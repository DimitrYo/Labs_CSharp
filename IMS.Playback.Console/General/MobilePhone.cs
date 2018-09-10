using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    public class MobilePhone : IDeviceBase {
        private List<IDeviceBase> Devices;
        public string Model { get; set; }

        public MobilePhone() {
            this.Manufacturer = "Meizu";
            Model = "M2";

            Devices = new List<IDeviceBase>();
        }

        public override string Info() {
            var text = "Phone information:\r\n";
            text += $"\tModel: {Model}\r\n";
            text += base.Info();

            return text;
        }

        public string GetFullDescription() {
            var text = Info();

            Devices.ForEach(delegate (IDeviceBase device) {
                text += device.Info();
            });

            return text;
        }

        public void DeviceList() {
            for (int i = 0; i < Devices.Count; i++) {
                Console.WriteLine($"{i + 1}: {Devices[i].GetType().ToString()}");
            }
            Console.WriteLine("\n");
        }
        public void AttachDevice(ref IDeviceBase deviceToInsert) {
                Devices.Add(deviceToInsert);
        }


        public void DettachDevice(IDeviceBase deviceToRemove) {
            var toDelete = (from device in Devices where device.GetType() == deviceToRemove.GetType() select device);

          // Devices.Remove();
        }
    }
}
