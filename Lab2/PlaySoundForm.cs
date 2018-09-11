using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace IMS.Playback.GUI {
    public partial class PlaySoundForm : Form {
        public MobilePhone myPhone { get; private set; }
        public IOutput output;

        public PlaySoundForm() {
            InitializeComponent();

            output = new OutputControl();
            myPhone = new MobilePhone(output);

            List<string> collection = new List<string>() { "iPhoneHeadset", "PhoneSpeaker", "LoudSpeaker", "SamsungHeadset", "UnofficialPhoneHeadset" };
            foreach (var item in collection) {
                PlaybackComponents.Items.Add(item);
            }
            PlaybackComponents.SetSelected(1, true);

        }


        private void applyClick(object sender, EventArgs e) {
            int selectedItem = PlaybackComponents.SelectedIndex + 1;
            Attach(selectedItem);
            myPhone.PlayLast();
            MsgTextBox.Text = output.TextOutput;

            // Getted from https://freemusicarchive.org/search/?sort=track_date_published&d=1&page=2&quicksearch=vivaldi
            var player = new SoundPlayer(Properties.Resources.Vivaldi);
            player.Play();

            output.WriteLine("");
        }

        public void Attach(int selectedItem) {


            PlaySound device;


            switch (selectedItem) {

                case 1:
                    device = new iPhoneHeadset(output);
                    break;
                case 2:
                    device = new PhoneSpeaker(output);
                    break;
                case 3:
                    device = new LoudSpeaker(output);
                    break;
                case 4:
                    device = new SamsungHeadset(output);
                    break;
                case 5:
                    device = new UnofficialPhoneHeadset(output);
                    break;
                default:
                    device = new PhoneSpeaker(output);
                    break;
            }

            output.WriteLine($"{device.GetType().Name} playback attached.");
            myPhone.AttachDevice(ref device);
        }

    }
}
