using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMS.Playback.GUI.Test {
    [TestClass]
    public class UnofficialPhoneHeadsetTest {
        [TestMethod]
        public void PlayTest() {
            //-- Arrange
            var output = new OutputControl();
            var soundDevice = new UnofficialPhoneHeadset(output);
            var expected = "UnofficialPhoneHeadset sound\r\n";
            //-- Act;
            soundDevice.Play(new object());
            var actual = output.TextOutput;
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
