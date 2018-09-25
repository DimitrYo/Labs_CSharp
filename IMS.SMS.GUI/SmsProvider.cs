using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IMS.SMS.GUI {
    public class SmsProvider {
        public delegate void SMSReceivedDelegate(string message);
        public event SMSReceivedDelegate SMSReceived;
        public event Action<Message> SMSReceivedMsg;

        private static int SmsCount { get; set; } = 0;
        private Timer GenerateMsgTimer;

        public void ThreadingTimerStart() {
            GenerateMsgTimer = new Timer(OnSmsGenerated, null, 0, 1000);
        }

        public void ThreadingTimerStartMsg() {
            GenerateMsgTimer = new Timer(OnSmsGeneratedMsg, null, 0, 1000);
        }

        public void ThreadingTimerStop() {
            GenerateMsgTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void OnSmsGenerated(object state) {
            var message = "DRYV";
            SmsCount += 1;
            SMSReceived?.BeginInvoke($"Message #{SmsCount} received: " + message, null, null);
        }

        public void OnSmsGeneratedMsg(object state) {
            SmsCount += 1;
            var msg = new Message {
                Id = SmsCount,
                User = Contacs.GetRandomContact(),
                Text = "You won a ticket to Mars!",
                ReceivingTime = DateTime.Now
            };
            SMSReceivedMsg?.BeginInvoke(msg, null, null);
        }

        public void Dispose() {
            GenerateMsgTimer.Dispose();
        }

    }

}
