using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.SMS.GUI {
    public class SmsProvider {
        public delegate void SMSReceivedDelegate(string message);
        public event SMSReceivedDelegate SMSReceived;

        private static int SmsCount { get; set; } = 0;
        private Timer GenerateMsgTimer;

        public SmsProvider(SMSReceivedDelegate del ) {
            SMSReceived += del;
            GenerateMsgTimer = new Timer();
            GenerateMsgTimer.Tick += OnSmsGenerated;
            GenerateMsgTimer.Interval = 1000;
            GenerateMsgTimer.Start();
        }

        public void OnSmsGenerated(object o,EventArgs e) {
            var message = "DRYV";
            SmsCount += 1;
            SMSReceived?.BeginInvoke( $"Message #{SmsCount} received: " + message, null, null);
        }
    }

}
