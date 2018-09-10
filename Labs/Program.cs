using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Phone {
    class Program {
        static void Main(string[] args) {
            var myPhone = new MobilePhone();
            Console.WriteLine(myPhone.GetFullDescription());
            Console.ReadKey();
        }
    }
}
