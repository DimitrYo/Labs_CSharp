using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace IMS.Playback.GUI.Test {
    [TestClass]
    public class PlaySoundFormTest {
        [TestMethod]
        public void AttachTest() {
            //-- Arrange
            using (var myForm = new PlaySoundForm()) {
                var expected = "iPhoneHeadset playback attached.\r\n";
                var output = new OutputControl();
                myForm.output = output;
                //-- Act;
                myForm.Attach(1);
                var actual = output.TextOutput;
                //-- Assert
                Assert.AreEqual(expected, actual);
            };
        }
    }
}
