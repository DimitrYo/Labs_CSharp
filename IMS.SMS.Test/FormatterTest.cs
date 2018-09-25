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

        [TestMethod]
        public void FormatWithDateTimeOnEndTest() {
            var expected = ']';
            var actual = Formatter.FormatWithDateTimeOnEnd(msg);
            Assert.AreEqual(expected, actual[actual.Length - 1]);
        }

        [TestMethod]
        public void FormatUpperCase() {
            var expected = 'E';
            var actual = Formatter.FormatUpperCase(msg);
            Assert.AreEqual(expected, actual[1]);
        }

        [TestMethod]
        public void FormatLowerCase() {
            var expected = 't';
            var actual = Formatter.FormatLowerCase(msg);
            Assert.AreEqual(expected, actual[0]);
        }
    }
}
