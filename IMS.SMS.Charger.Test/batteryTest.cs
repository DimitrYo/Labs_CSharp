using System;
using System.Threading;
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
        public void TestBatteryLevelMinMax() {
            foreach (var item in (BatteryMethod[]) (typeof(BatteryMethod)).GetEnumValues()) {
                TestBatteryLevelMin(item);
            }

            foreach (var item in (BatteryMethod[])(typeof(BatteryMethod)).GetEnumValues()) {
                TestBatteryLevelMax(item);
            }
        }


        [TestMethod]
        public void TestBatteryLevelIncDec() {
            foreach (var item in (BatteryMethod[])(typeof(BatteryMethod)).GetEnumValues()) {
                TestBatteryLevelDecreaseChargeLevel(item);
            }

            foreach (var item in (BatteryMethod[])(typeof(BatteryMethod)).GetEnumValues()) {
                TestBatteryLevelIncreaseChargeLevel(item);
            }
        }

        private void TestBatteryLevelIncreaseChargeLevel(BatteryMethod method) {
            //-- Arrange
            var btr = new Battery(method);
            var expected = 98;

            //-- Act;
            btr.Start();
            btr.AttachCharger();

            Thread.Sleep(TimeSpan.FromSeconds(6));
            var actual = btr.ChargeLevel;
            btr.DettachCharger();

            //-- Assert
            Assert.IsTrue(expected <= actual);
            btr.Dispose();
        }

        private void TestBatteryLevelDecreaseChargeLevel(BatteryMethod method) {
            //-- Arrange
            var btr = new Battery(method);
            var expected = 90;

            //-- Act;
            btr.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            var actual = btr.ChargeLevel;

            //-- Assert
            Assert.IsTrue(expected >= actual);
            btr.Dispose();
        }
    }
}
