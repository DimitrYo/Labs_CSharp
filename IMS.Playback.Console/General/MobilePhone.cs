using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    public class MobilePhone : IDeviceBase {
        private List<PlaySound> SoundDevices;
        private IOutput output;
        public string Model { get; set; }

        public MobilePhone(IOutput output) {
            this.output = output;
            this.Manufacturer = "Meizu";
            Model = "M2";

            SoundDevices = new List<PlaySound>();
        }

        public override string Info() {
            var text = "Phone information:\r\n";
            text += $"\tModel: {Model}\r\n";
            text += base.Info();

            return text;
        }

        public string GetFullDescription() {
            var text = Info();

            text += ("\tSound devices\n");

            SoundDevices.ForEach(delegate (PlaySound device) {
                text += ("\t----\n");
                text += device.Info();
            });

            return text;
        }

        public void DeviceList() {
            Console.WriteLine("Attached devices\n");
            for (int i = 0; i < SoundDevices.Count; i++) {
                Console.WriteLine($"{i + 1}: {SoundDevices[i].GetType().Name}");
            }
            Console.WriteLine("\n");
        }
        public void AttachDevice(ref PlaySound deviceToInsert) {
            SoundDevices.Add(deviceToInsert);
        }

        public void DettachDevice(int deviceNumber) {
            SoundDevices.RemoveAt(deviceNumber - 1);
        }

        public void DeviceInfo(int deviceNumver) {
            Console.WriteLine(SoundDevices[deviceNumver - 1].Info());
        }

        public void Play(int deviceNumver) {
            output.WriteLine($"\n{SoundDevices[deviceNumver - 1].GetType().Name} playback selected");
            output.WriteLine("Set playback to Mobile");
            output.WriteLine("Play sound in Mobile");
            SoundDevices[deviceNumver - 1].Play(new object());
        }

        public void PlayLast() {
            output.WriteLine($"{SoundDevices[SoundDevices.Count - 1].GetType().Name} playback selected");
            output.WriteLine("Set playback to Mobile");
            output.WriteLine("Play sound in Mobile");
            SoundDevices[SoundDevices.Count - 1].Play(new object());
        }
    }
}
