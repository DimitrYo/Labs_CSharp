using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMS.Playback.GUI.Test {
    [TestClass]
    public class PhoneSpeakerTest {
        [TestMethod]
        public void PlayTest() {
            //-- Arrange
            var output = new OutputControl();
            var soundDevice = new PhoneSpeaker(output);
            var expected = "PhoneSpeaker sound\r\n";
            //-- Act;
            soundDevice.Play(new object());
            var actual = output.TextOutput;
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
