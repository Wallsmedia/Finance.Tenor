// Copyright © Alexander Paskhin 2018-2020. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Period.Test
{

    [TestClass]
    public class UnitTestOfParse
    {
        [TestMethod]
        public void TestParse_1y_PositiveResult()
        {
            string tenor = "100y";
            Tenor res = Tenor.Parse(tenor);
            Assert.AreEqual(100, res.Years);
            Assert.AreEqual(0, res.Months);
            Assert.AreEqual(0, res.Weeks);
            Assert.AreEqual(0, res.Days);
        }

        [TestMethod]
        public void TestParse_1y1m_PositiveResult()
        {
            string tenor = "1y1m";
           Tenor res =Tenor.Parse(tenor);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(1, res.Months);
            Assert.AreEqual(0, res.Weeks);
            Assert.AreEqual(0, res.Days);
        }

        [TestMethod]
        public void TestParse_1y1m1w_PositiveResult()
        {
            string tenor = "1y1m1w";
           Tenor res =Tenor.Parse(tenor);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(1, res.Months);
            Assert.AreEqual(1, res.Weeks);
            Assert.AreEqual(0, res.Days);
        }

        [TestMethod]
        public void TestParse_1y1m1w1d_PositiveResult()
        {
            string tenor = "1y1m1w1d";
           Tenor res =Tenor.Parse(tenor);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(1, res.Months);
            Assert.AreEqual(1, res.Weeks);
            Assert.AreEqual(1, res.Days);
        }

        [TestMethod]
        public void TestParse_1d1w1m1y_PositiveResult()
        {
            string tenor = "1d1w1m1y";
           Tenor res =Tenor.Parse(tenor);
            Assert.AreEqual(1, res.Years);
            Assert.AreEqual(1, res.Months);
            Assert.AreEqual(1, res.Weeks);
            Assert.AreEqual(1, res.Days);
        }

        [TestMethod]
        public void TestParse_y1_NegativeException()
        {
            string tenor = "y1";
            Assert.ThrowsException<FormatException>(() =>
            {
               Tenor res =Tenor.Parse(tenor);
            });
        }

        [TestMethod]
        public void TestParse_1ym_NegativeException()
        {
            string tenor = "1ym";
            Assert.ThrowsException<FormatException>(() =>
            {
               Tenor res =Tenor.Parse(tenor);
            });
        }

        [TestMethod]
        public void TestParse_1y1m1q_NegativeException()
        {
            string tenor = "1y1m1q";
            Assert.ThrowsException<FormatException>(() =>
            {
               Tenor res =Tenor.Parse(tenor);
            });
        }

        [TestMethod]
        public void TestParse_empty_NegativeException()
        {
            string tenor = "";
            Assert.ThrowsException<FormatException>(() =>
            {
               Tenor res =Tenor.Parse(tenor);
            });
        }

        [TestMethod]
        public void TestParse_null_NegativeException()
        {
            string tenor = null;
            Assert.ThrowsException<FormatException>(() =>
            {
               Tenor res =Tenor.Parse(tenor);
            });
        }

    }
}
