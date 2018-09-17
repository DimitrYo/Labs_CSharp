using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMS.Playback.GUI;
using IMS.Playback;

namespace IMS.Playback.GUI.Test {
    [TestClass]
    public class iPhoneHeadsetTest {
        [TestMethod]
        public void PlayTest() {
            //-- Arrange
            var output = new OutputControl();
            var soundDevice = new iPhoneHeadset(output);
            var expected = "iPhoneHeadset sound\r\n";
            //-- Act;
            soundDevice.Play(new object());
            var actual = output.TextOutput;
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
