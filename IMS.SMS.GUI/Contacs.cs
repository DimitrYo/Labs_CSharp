using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.GUI {
    public class Contacts {
        public static List<string> ContactsList = new List<string> { "DRYV", "SAN", "KUM", "DOM", "MEM", "REM", "GAP" };
        private static Random rnd = new Random();

        public static string GetRandomContact() {
            return ContactsList[rnd.Next(0, ContactsList.Count)];
        }
    }
}
