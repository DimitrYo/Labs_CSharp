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
        List<Message> msgList;

        public SmsStorageTest() {
            msgList = new List<Message> {
                new Message {
                    Text = "MARS",
                    User = "DRYV"
                }
            };
        }

        [TestMethod]
        public void TestSmsGenerating() {
            //-- Arrange
            var mdl = new SmsStorage();
            var expected = 5;

            mdl.StyleMessage = "Start with DateTime";
            mdl.StyleChanged();
            //-- Act;
            mdl.Start();
            Thread.Sleep(5000);
            mdl.Stop();
            var actual = mdl.MsgTextListGet.Count;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestFilterByMaxDateTime() {
            //-- Arrange
            var expected = 1;

            var mdl = new SmsStorage();
            var time = DateTime.Now;
            msgList[0].ReceivingTime = time;

            mdl.MaxDateTimeToFilter = time + TimeSpan.FromSeconds(5);
            mdl.FilterByMaxDateChecked = true;

            //-- Act;
            var actual = mdl.FilterByMaxDateTime(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFilterByMaxDateTimeZero() {
            //-- Arrange
            var expected = 0;

            var mdl = new SmsStorage();
            var time = DateTime.Now;
            msgList[0].ReceivingTime = time;

            mdl.MaxDateTimeToFilter = time - TimeSpan.FromSeconds(5);
            mdl.FilterByMaxDateChecked = true;

            //-- Act;
            var actual = mdl.FilterByMaxDateTime(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFilterByMinDateTime() {
            //-- Arrange
            var expected = 1;

            var mdl = new SmsStorage();
            var time = DateTime.Now;
            msgList[0].ReceivingTime = time;

            mdl.MinDateTimeToFilter = time - TimeSpan.FromSeconds(5);
            mdl.FilterByMinDateChecked = true;

            //-- Act;
            var actual = mdl.FilterByMinDateTime(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFilterByMinDateTimeZero() {
            //-- Arrange
            var expected = 0;

            var mdl = new SmsStorage();
            var time = DateTime.Now;
            msgList[0].ReceivingTime = time;

            mdl.MinDateTimeToFilter = time + TimeSpan.FromSeconds(5);
            mdl.FilterByMinDateChecked = true;

            //-- Act;
            var actual = mdl.FilterByMinDateTime(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestFilterByUser() {
            //-- Arrange
            var expected = 1;

            var mdl = new SmsStorage();

            mdl.UserToFilter = "DRYV";

            //-- Act;
            var actual = mdl.FilterByUser(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFilterByUserZero() {
            //-- Arrange
            var expected = 0;

            var mdl = new SmsStorage();

            mdl.UserToFilter = "DRYV1";

            //-- Act;
            var actual = mdl.FilterByUser(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestFilterByTextZero() {
            //-- Arrange
            var expected = 0;

            var mdl = new SmsStorage();

            mdl.TextToFilter = "DRYV1";

            //-- Act;
            var actual = mdl.FilterByText(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFilterByText() {
            //-- Arrange
            var expected = 1;

            var mdl = new SmsStorage();

            mdl.TextToFilter = "DRYV";

            //-- Act;
            var actual = mdl.FilterByText(msgList).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestUpdateView() {
            //-- Arrange
            var mdl = new SmsStorage();
            var form = new SmsFilter();
            mdl.AttachIModelObserver((IModelObserver)form);

            mdl.TextToFilter = "DRYV";

            //-- Act;
            mdl.UpdateView();
        }

        [TestMethod]
        public void TestStyleChanged() {
            //-- Arrange
            var expected = true;
            var mdl = new SmsStorage();

            mdl.StyleMessage = "Start with DateTime";

            //-- Act;
            mdl.StyleChanged();
            var actual = mdl.FormatterMsgEventIsSubscribed(Message.FormatWithDateTimeOnStart);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStyleChanged4Times() {
            //-- Arrange
            var expected = true;
            var mdl = new SmsStorage();

            //-- Act;
            mdl.StyleMessage = "Start with DateTime";
            mdl.StyleChanged();

            mdl.StyleMessage = "End with DateTime";
            mdl.StyleChanged();

            mdl.StyleMessage = "Uppercase";
            mdl.StyleChanged();

            mdl.StyleMessage = "Lowercase";
            mdl.StyleChanged();
            var actual = mdl.FormatterMsgEventIsSubscribed(Message.FormatLowerCase);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAttachIModelObserver() {
            //-- Arrange
            var expected = true;
            var form = new SmsFilter();
            var mdl = new SmsStorage();

            //-- Act;
            mdl.AttachIModelObserver((IModelObserver)form);
            var actual = mdl.IsSubscribedAttachIModelObserver();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void TestViewChanged() {
            //-- Arrange
            var timeMin = DateTime.Now;
            var timeMax = timeMin + TimeSpan.FromSeconds(5);
            var mdl = new SmsStorage();

            mdl.StyleMessage = "Start with DateTime";
            var viewArg = new ViewEventArgs("DRYV", "text",
            timeMin, timeMax,
            "None",
            true, true);

            //-- Act;
            mdl.ViewChanged(viewArg);

            //-- Assert
            Assert.AreEqual(timeMin, mdl.MinDateTimeToFilter);
            Assert.AreEqual(timeMax, mdl.MaxDateTimeToFilter);
            Assert.AreEqual("None", mdl.StyleMessage);
            Assert.AreEqual(true, mdl.FilterByMaxDateChecked);
            Assert.AreEqual(true, mdl.FilterByMinDateChecked);
            Assert.AreEqual("DRYV", mdl.UserToFilter);
            Assert.AreEqual("text", mdl.TextToFilter);
        }

    }
}
