using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMS.SMS.GUI;
using System.Reflection;
using IMS.SMS.Filter;
using System.Linq;

using Message = IMS.SMS.GUI.Message;

namespace IMS.SMS.Filter.GUI.Test {
    [TestClass]
    public class SmsFilterTest {
        [TestMethod]
        public void TestMethod1() {

            var form = new SmsFilter();
            //var FilterByMaxDate = form.GetType().GetMethod("FilterByMaxDate", BindingFlags.Instance | BindingFlags.NonPublic);

        }
    }
}
