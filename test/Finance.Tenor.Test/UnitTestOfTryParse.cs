// Copyright © Alexander Paskhin 2018. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Period.Test
{
    [TestClass]
    public class UnitTestOfTryParse
    {
        [TestMethod]
        public void TestTryParse_1y_PositiveResult()
        {
            string tenor = "1y";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(0, res.Months);
            Assert.AreEqual(0, res.Weeks);
            Assert.AreEqual(0, res.Days);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestTryParse_1y1m_PositiveResult()
        {
            string tenor = "1y1m";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(1, res.Months);
            Assert.AreEqual(0, res.Weeks);
            Assert.AreEqual(0, res.Days);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestTryParse_1y1m1w_PositiveResult()
        {
            string tenor = "1y1m1w";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(1, res.Months);
            Assert.AreEqual(1, res.Weeks);
            Assert.AreEqual(0, res.Days);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestTryParse_1y1m1w1d_PositiveResult()
        {
            string tenor = "1y1m1w1d";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(1, res.Months);
            Assert.AreEqual(1, res.Weeks);
            Assert.AreEqual(1, res.Days);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestTryParse_1d1w1m1y_PositiveResult()
        {
            string tenor = "1d1w1m1y";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(1, res.Months);
            Assert.AreEqual(1, res.Weeks);
            Assert.AreEqual(1, res.Days);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestTryParse_y1_Negative()
        {
            string tenor = "y1";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void TestTryParse_1ym_Negative()
        {
            string tenor = "1ym";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void TestTryParse_1y1m1q_Negative()
        {
            string tenor = "1y1m1q";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void TestTryParse_empty_Negative()
        {
            string tenor = "";
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void TestTryParse_null_Negative()
        {
            string tenor = null;
            bool flag =Tenor.TryParse(tenor, out Tenor res);
            Assert.IsFalse(flag);
        }

    }
}
