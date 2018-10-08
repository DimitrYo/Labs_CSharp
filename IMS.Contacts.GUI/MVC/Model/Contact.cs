using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI {
    public class Contact {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> PhoneNumbers { get; set; }

        public override string ToString() {
            return Name + Surname;
        }

        private static List<string> ContactsList = new List<string> { "DRYV", "SAN", "KUM", "DOM", "MEM", "REM", "GAP" };
        private static Random rnd = new Random();

        public static string GetRandomContact() {
            return ContactsList[rnd.Next(0, ContactsList.Count)];
        }
    }
}
