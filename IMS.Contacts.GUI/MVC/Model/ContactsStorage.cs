using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI.MVC.Model {
    public class ContactsStorage {
        List<Contact> contacs;

        void Add(Contact cont) {

        }
        void Remove(Contact cont) {

        }
        List<string> GetNumbers() {
            var numberList = contacs.SelectMany(c => c.PhoneNumbers).ToList();
            return numberList;
        }
    }
}
