using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.GUI {
    public class Formatter {
        public static string FormatWithDateTimeOnStart(string message) {
            return $"[{DateTime.Now}] {message}";
        }

        public static string FormatWithDateTimeOnEnd(string message) {
            return $"{message} [{DateTime.Now}] ";
        }

        public static string FormatUpperCase(string message) {
            return message.ToUpper();
        }

        public static string FormatLowerCase(string message) {
            return message.ToLower();
        }
    }
}
