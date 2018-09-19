using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMS.SMS.GUI;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;

namespace IMS.SMS.Test {
    [TestClass]
    public class SmsProviderTest {
        private List<string> receivedEvents = new List<string>();
        private SmsProvider SMSProvider;

        public void ReceiveEvent(string msg) {
            
            receivedEvents.Add(msg);
        }

        [TestMethod]
        public void RaisingEvents() {

            SMSProvider = new SmsProvider(new SmsProvider.SMSReceivedDelegate(ReceiveEvent));
            Thread.Sleep(4000);
            Assert.AreEqual(4, receivedEvents.Count);
            Assert.IsNotNull(receivedEvents);
            Assert.AreNotEqual(0, receivedEvents.Count);
        }

    }
}
