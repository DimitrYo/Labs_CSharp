using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contacts.GUI {
    public class ContactsFactory {
        public static int Number { get; set; }
        static ContactsFactory _instance;

        private ContactsFactory() {
            _instance = new ContactsFactory();
            ContactsFactory.Number = 0;
        }

        static ContactsFactory GetFactory() {
            return _instance;
        }
        public Contact NewContact() {
            Number += 1;
            return new Contact {
                Name = Contact.GetRandomContact(),
                PhoneNumbers = {
                    Number.ToString()
                },
                Surname = Contact.GetRandomContact()
            };
        }

        public List<Contact> NewContacts(int number) {
            List<Contact> contacts = new List<Contact>();
            for (int i = 0; i < number; i++) {
                contacts.Add(NewContact());
            }
            return contacts;
        }
    }
}
