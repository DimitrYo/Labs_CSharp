using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IMS.Playback {
    class Program {
        static void Main(string[] args) {

            var output = new OutputConsole();
            MobilePhone myPhone = new MobilePhone(output);
            Console.WriteLine(myPhone.GetFullDescription());
            Run(ref myPhone);

        }

        public static void Run(ref MobilePhone myPhone) {
            while (true) {

                Console.WriteLine("Select option to do(specify index)");
                Console.WriteLine("1: Attach component");
                Console.WriteLine("2: Detach component");
                Console.WriteLine("3: Show full mobile description");
                Console.WriteLine("4: Play component");
                Console.WriteLine("5: List of devices attached");
                Console.WriteLine("6: Device info");
                Console.WriteLine("q: For exit");

                try {

                    var input = Console.ReadKey().KeyChar.ToString();
                    if (input == "q") {
                        break;
                    }
                    var choosOperation = int.Parse(input);
                    Console.WriteLine("\n");

                    switch (choosOperation) {
                        case 1:
                            Attach(ref myPhone);
                            break;

                        case 2:
                            Console.WriteLine("Select component to dettach(specify index)");
                            myPhone.DeviceList();
                            var deviceNumber = int.Parse((Console.ReadKey().KeyChar.ToString()));
                            myPhone.DettachDevice(deviceNumber);

                            break;
                        case 3:
                            Console.WriteLine(myPhone.GetFullDescription());
                            break;
                        case 4:
                            Console.WriteLine("Select component to dettach(specify index)");
                            myPhone.DeviceList();
                            var devicePlayNumber = int.Parse((Console.ReadKey().KeyChar.ToString()));
                            myPhone.Play(devicePlayNumber);

                            break;
                        case 5:
                            myPhone.DeviceList();
                            break;
                        case 6:
                            Console.WriteLine("Select component to dettach(specify index)");
                            myPhone.DeviceList();
                            var deviceInfoNumber = int.Parse((Console.ReadKey().KeyChar.ToString()));
                            myPhone.DeviceInfo(deviceInfoNumber);
                            break;
                    }

                }
                catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }

            }
        }

        public static void Attach(ref MobilePhone myPhone) {
            Console.WriteLine("Select component to attach(specify index)");
            List<string> soundComponent = new List<string>() { "iPhoneHeadset", "PhoneSpeaker", "LoudSpeaker", "SamsungHeadset", "UnofficialPhoneHeadset" };
            for (int i = 0; i < soundComponent.Count; i++) {
                Console.WriteLine($"{i + 1}: Attach {soundComponent[i]}");
            }

            var chooseAttachType = int.Parse((Console.ReadKey().KeyChar.ToString()));
            Console.WriteLine("\n");

            PlaySound device;
            var output1 = new OutputConsole();

            switch (chooseAttachType) {

                case 1:
                    device = new iPhoneHeadset(output1);
                    break;
                case 2:
                    device = new PhoneSpeaker(output1);
                    break;
                case 3:
                    device = new LoudSpeaker(output1);
                    break;
                case 4:
                    device = new SamsungHeadset(output1);
                    break;
                case 5:
                    device = new UnofficialPhoneHeadset(output1);
                    break;
                default:
                    device = new PhoneSpeaker(output1);
                    break;
            }

            myPhone.AttachDevice(ref device);
        }

    }
}
