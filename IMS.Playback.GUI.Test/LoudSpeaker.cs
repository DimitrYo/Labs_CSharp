using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMS.Playback.GUI.Test {
    [TestClass]
    public class LoudSpeakerTest {
        [TestMethod]
        public void PlayTest() {
            //-- Arrange
            var output = new OutputControl();
            var soundDevice = new LoudSpeaker(output);
            var expected = "LoudSpeaker sound\r\n";
            //-- Act;
            soundDevice.Play(new object());
            var actual = output.TextOutput;
            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
