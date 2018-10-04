using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMS.SMS.GUI;
using System.Reflection;
using IMS.SMS.Filter;
using System.Linq;

using Message = IMS.SMS.GUI.Message;
using System.Threading;
using System;

namespace IMS.SMS.Filter.GUI.Test {
    [TestClass]
    public class SmsStorageTest {
        [TestMethod]
        public void TestSmsGenerating() {
            //-- Arrange
            var mdl = new SmsStorage();
            var expected = 5;

            //-- Act;
            mdl.StartTimer();
            Thread.Sleep(5000);
            mdl.StopTimer();
            var actual = mdl.MsgTextListGet.Count;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void AdddingMessages() {
            //-- Arrange
            var expected = 1;

            var mdl = new SmsStorage();
            var time = DateTime.Now;
            var msgList = new List<Message> {
                new Message {
                    Text = "MARS",
                    ReceivingTime = time
                }
            };

            mdl.MaxDateTimeToFilter = time + TimeSpan.FromSeconds(2);

            //-- Act;
            var actual = mdl.FilterByMaxDateTime(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
