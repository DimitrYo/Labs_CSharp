using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.GUI {
    public class Contacs {
        private static List<string> contacts = new List<string> { "DRYV", "SAN", "KUM", "DOM", "MEM", "REM", "GAP" };
        private static Random rnd = new Random();

        public static string GetRandomContact() {
            return contacts[rnd.Next(0, contacts.Count)];
        }
    }
}
