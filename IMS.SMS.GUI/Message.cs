using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.GUI {
    public class Message {
        public int Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime ReceivingTime { get; set; } 

        public int TimeFormatDisplay { get; set; } = 0;

        public override string ToString() {
            switch (TimeFormatDisplay) {
                case 1:
                return $"[{ReceivingTime}] Message #{this.Id} from {this.User} received: {this.Text}";
                case 2:
                return $"Message #{this.Id} from {this.User} received: {this.Text} [{ReceivingTime}]";
                default:
                return $"Message #{this.Id} from {this.User} received: {this.Text}";
            }

        }

        public static Message FormatWithDateTimeOnStart(Message message) {
            message.TimeFormatDisplay = 1;
            return message;
        }

        public static Message FormatWithDateTimeOnEnd(Message message) {
            message.TimeFormatDisplay = 2;
            return message;
        }

        public static Message FormatUpperCase(Message message) {
            message.Text = message.Text.ToUpper();
            return message;
        }

        public static Message FormatLowerCase(Message message) {
            message.Text = message.Text.ToLower();
            return message;
        }
    }
}
