using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMS.Playback;

namespace IMS.Playback.GUI.Test {
    [TestClass]
    public class SamsungHeadsetTest {
        [TestMethod]
        public void PlayTest() {
            //-- Arrange
            var output = new OutputControl();
            var soundDevice = new SamsungHeadset(output);
            var expected = "SamsungHeadset sound\r\n";
            //-- Act;
            soundDevice.Play(new object());
            var actual = output.TextOutput;
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
