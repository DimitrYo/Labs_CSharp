using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMS.SMS.GUI;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.SMS.Test {
    /// <summary>
    /// Summary description for SmsFormTest
    /// </summary>
    [TestClass]
    public class SmsFormTest {


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SmsFormEvents() {
            //-- Arrange
            var form = new SmsForm();
            Application.Run(form);

            Thread.Sleep(1000);
            var expected = "M";
            //-- Act;
            var actual = form.GetLastTestMessageBox(new object());

            //-- Assert
            Assert.AreEqual(expected, actual[0]);
            form.Dispose();
        }
    }
}
