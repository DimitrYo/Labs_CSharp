using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Playback {
    class Program {
        static void Main(string[] args) {
            var myPhone = new MobilePhone();
            Console.WriteLine(myPhone.GetFullDescription());


            while (true) {

                Console.WriteLine("Select option to do(specify index)");
                Console.WriteLine("1: Attach component");
                Console.WriteLine("2: Detach component");
                Console.WriteLine("3: Show description");
                Console.WriteLine("4: Play component");
                Console.WriteLine("5: List of devices attached");
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
                            Console.WriteLine("Select component to attach(specify index)");
                            List<string> soundComponent = new List<string>() { "iPhoneHeadset", "PhoneSpeaker", "LoudSpeaker", "SamsungHeadset", "UnofficialPhoneHeadset" };
                            for (int i = 0; i < soundComponent.Count; i++) {
                                Console.WriteLine($"{i}: Attach {soundComponent[i]}");
                            }

                            var chooseAttachType = int.Parse((Console.ReadKey().KeyChar.ToString()));
                            Console.WriteLine("\n");

                            IDeviceBase device;

                            switch (chooseAttachType) {
                                case 1:
                                    device = new iPhoneHeadset();
                                    break;
                                case 2:
                                    device = new PhoneSpeaker();
                                    break;
                                case 3:
                                    device = new LoudSpeaker();
                                    break;
                                case 4:
                                    device = new SamsungHeadset();
                                    break;
                                case 5:
                                    device = new UnofficialPhoneHeadset();
                                    break;
                                default:
                                    device = new PhoneSpeaker();
                                    break;
                            }

                            myPhone.AttachDevice(ref device);
                            break;

                        case 2:
                            Console.WriteLine("Select component to dettach(specify index)");
                            myPhone.GetFullDescription();

                            break;
                        case 3:
                            Console.WriteLine(myPhone.GetFullDescription());
                            break;
                        case 4:
                            Console.WriteLine(myPhone.GetFullDescription());
                            break;
                        case 5:
                            myPhone.DeviceList();
                            break;
                    }

                }
                catch (Exception e) {
                    Console.WriteLine(e.ToString());
                    //throw;
                }

            }

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
