using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMS.SMS.GUI;

namespace IMS.SMS.Test {
    /// <summary>
    /// Summary description for FormatterTest
    /// </summary>
    [TestClass]
    public class FormatterTest {
        private string msg = "tEst";

        [TestMethod]
        public void FormatWithDateTimeOnStartTest() {
            var expected = '[';
            var actual = Formatter.FormatWithDateTimeOnStart(msg);
            Assert.AreEqual(expected,actual[0]);
        }

        public void FormatWithDateTimeOnEndTest() {
            //
            // TODO: Add test logic here
            //
            var expected = ']';
            var actual = Formatter.FormatWithDateTimeOnEnd(msg);
            Assert.AreEqual(expected, actual[actual.Length - 1]);
        }

        public void FormatUpperCase() {
            //
            // TODO: Add test logic here
            //
            var expected = 'T';
            var actual = Formatter.FormatUpperCase(msg);
            Assert.AreEqual(expected, actual[0]);
        }

        public void FormatLowerCase() {
            //
            // TODO: Add test logic here
            //
            var expected = 'E';
            var actual = Formatter.FormatLowerCase(msg);
            Assert.AreEqual(expected, actual[1]);
        }
    }
}
