using System;
using IMS.SMS.Charger.GUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMS.SMS.Charger.Test {
    [TestClass]
    public class BatteryTest {

        public void TestBatteryLevelMin(BatteryMethod method) {
            //-- Arrange
            var btr = new Battery(method);
            var expected = 0;

            //-- Act;
            btr.OnBatteryConsuming(200);
            var actual = btr.ChargeLevel;

            //-- Assert
            Assert.AreEqual(expected, actual);
            btr.Dispose();
        }

        public void TestBatteryLevelMax(BatteryMethod method) {
            //-- Arrange
            var btr = new Battery(method);
            var expected = 100;

            //-- Act;
            btr.AttachCharger();
            btr.OnBatteryCharger(200);
            var actual = btr.ChargeLevel;
            btr.DettachCharger();

            //-- Assert
            Assert.AreEqual(expected, actual);
            btr.Dispose();
        }

        [TestMethod]
        public void TestBatteryLevel() {
            foreach (var item in (BatteryMethod[]) (typeof(BatteryMethod)).GetEnumValues()) {
                TestBatteryLevelMin(item);
            }

            foreach (var item in (BatteryMethod[])(typeof(BatteryMethod)).GetEnumValues()) {
                TestBatteryLevelMax(item);
            }
        }
    }
}
