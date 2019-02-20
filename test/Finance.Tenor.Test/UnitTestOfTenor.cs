// Copyright © Alexander Paskhin 2018. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Period.Test
{
    [TestClass]
    public class UnitTestOfTenor
    {
        [TestMethod]
        public void TestParse_Constructor_PositiveResult()
        {
           Tenor tenor = new Tenor(1, 1, 1, 1);
            Assert.AreEqual(1, tenor.Years);
            Assert.AreEqual(1, tenor.Months);
            Assert.AreEqual(1, tenor.Weeks);
            Assert.AreEqual(1, tenor.Days);
        }

        [TestMethod]
        public void TestParse_Constructor_Negative1()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
               Tenor tenor = new Tenor(-1, 1, 1, 1);
            });
        }

        [TestMethod]
        public void TestParse_Constructor_Negative2()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
               Tenor tenor = new Tenor(1, -1, 1, 1);
            });
        }


        [TestMethod]
        public void TestParse_Constructor_Negative3()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
               Tenor tenor = new Tenor(1, 1, -1, 1);
            });
        }

        [TestMethod]
        public void TestParse_Constructor_Negative4()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
               Tenor tenor = new Tenor(1, 1, 1, -1);
            });
        }

        [TestMethod]
        public void TestParse_Compare_Positive()
        {
           Tenor tenorLow = new Tenor(0, 0, 0, 1);
           Tenor tenorMid = new Tenor(0, 0, 1, 1);
           Tenor tenorMid2 = new Tenor(0, 0, 0, 8);
           Tenor tenorHigh = new Tenor(0, 1, 1, 1);

            Assert.AreEqual(-1,Tenor.Compare(tenorLow, tenorMid));
            Assert.AreEqual(-1,Tenor.Compare(tenorLow, tenorHigh));
            Assert.AreEqual(-1,Tenor.Compare(tenorMid, tenorHigh));

            Assert.AreEqual(0,Tenor.Compare(tenorLow, tenorLow));
            Assert.AreEqual(0,Tenor.Compare(tenorMid, tenorMid));
            Assert.AreEqual(0,Tenor.Compare(tenorMid, tenorMid2));
            Assert.AreEqual(0,Tenor.Compare(tenorHigh, tenorHigh));

            Assert.AreEqual(1,Tenor.Compare(tenorMid, tenorLow));
            Assert.AreEqual(1,Tenor.Compare(tenorHigh, tenorLow));
            Assert.AreEqual(1,Tenor.Compare(tenorHigh, tenorMid));
        }

        [TestMethod]
        public void TestParse_CompareTo_Positive1()
        {
           Tenor tenorLow = new Tenor(0, 0, 0, 1);
           Tenor tenorMid = new Tenor(0, 0, 1, 1);
           Tenor tenorMid2 = new Tenor(0, 0, 0, 8);
           Tenor tenorHigh = new Tenor(0, 1, 1, 1);

            Assert.AreEqual(-1, tenorLow.CompareTo(tenorMid));
            Assert.AreEqual(-1, tenorLow.CompareTo(tenorHigh));
            Assert.AreEqual(-1, tenorMid.CompareTo(tenorHigh));

            Assert.AreEqual(0, tenorLow.CompareTo(tenorLow));
            Assert.AreEqual(0, tenorMid.CompareTo(tenorMid));
            Assert.AreEqual(0, tenorMid.CompareTo(tenorMid2));
            Assert.AreEqual(0, tenorHigh.CompareTo(tenorHigh));

            Assert.AreEqual(1, tenorMid.CompareTo(tenorLow));
            Assert.AreEqual(1, tenorHigh.CompareTo(tenorLow));
            Assert.AreEqual(1, tenorHigh.CompareTo(tenorMid));
        }

        [TestMethod]
        public void TestParse_CompareTo_Positive2()
        {
           Tenor tenorLow = new Tenor(0, 0, 0, 1);
           Tenor tenorMid = new Tenor(0, 0, 1, 1);
           Tenor tenorMid2 = new Tenor(0, 0, 0, 8);
           Tenor tenorHigh = new Tenor(0, 1, 1, 1);

            Assert.AreEqual(-1, tenorLow.CompareTo((object)tenorMid));
            Assert.AreEqual(-1, tenorLow.CompareTo((object)tenorHigh));
            Assert.AreEqual(-1, tenorMid.CompareTo((object)tenorHigh));

            Assert.AreEqual(0, tenorLow.CompareTo((object)tenorLow));
            Assert.AreEqual(0, tenorMid.CompareTo((object)tenorMid));
            Assert.AreEqual(0, tenorMid.CompareTo((object)tenorMid2));
            Assert.AreEqual(0, tenorHigh.CompareTo((object)tenorHigh));

            Assert.AreEqual(1, tenorMid.CompareTo((object)tenorLow));
            Assert.AreEqual(1, tenorHigh.CompareTo((object)tenorLow));
            Assert.AreEqual(1, tenorHigh.CompareTo((object)tenorMid));

            Assert.AreEqual(1, tenorMid.CompareTo(null));
            Assert.AreEqual(1, tenorHigh.CompareTo(null));
            Assert.AreEqual(1, tenorHigh.CompareTo(null));

        }

        public void TestParse_CompareTo_Negative2()
        {
           Tenor tenorLow = new Tenor(0, 0, 0, 1);
            Assert.ThrowsException<ArgumentException>(() => { var x =tenorLow.CompareTo(new object()); });
        }

        [TestMethod]
        public void TestParse_Equals_Positive1()
        {
           Tenor tenorLow = new Tenor(0, 0, 0, 1);
           Tenor tenorMid = new Tenor(0, 0, 1, 1);
           Tenor tenorMid2 = new Tenor(0, 0, 0, 8);
           Tenor tenorHigh = new Tenor(0, 1, 1, 1);

            Assert.AreEqual(false, tenorLow.Equals(tenorMid));
            Assert.AreEqual(false, tenorLow.Equals(tenorHigh));
            Assert.AreEqual(false, tenorMid.Equals(tenorHigh));

            Assert.AreEqual(true, tenorLow.Equals(tenorLow));
            Assert.AreEqual(true, tenorMid.Equals(tenorMid));
            Assert.AreEqual(true, tenorMid.Equals(tenorMid2));
            Assert.AreEqual(true, tenorHigh.Equals(tenorHigh));

            Assert.AreEqual(false, tenorMid.Equals(tenorLow));
            Assert.AreEqual(false, tenorHigh.Equals(tenorLow));
            Assert.AreEqual(false, tenorHigh.Equals(tenorMid));
        }


        [TestMethod]
        public void TestParse_Equals_Positive2()
        {
           Tenor tenorLow = new Tenor(0, 0, 0, 1);
           Tenor tenorMid = new Tenor(0, 0, 1, 1);
           Tenor tenorMid2 = new Tenor(0, 0, 0, 8);
           Tenor tenorHigh = new Tenor(0, 1, 1, 1);

            Assert.AreEqual(false, tenorLow.Equals((object)tenorMid));
            Assert.AreEqual(false, tenorLow.Equals((object)tenorHigh));
            Assert.AreEqual(false, tenorMid.Equals((object)tenorHigh));

            Assert.AreEqual(true, tenorLow.Equals((object)tenorLow));
            Assert.AreEqual(true, tenorMid.Equals((object)tenorMid));
            Assert.AreEqual(true, tenorMid.Equals((object)tenorMid2));
            Assert.AreEqual(true, tenorHigh.Equals((object)tenorHigh));

            Assert.AreEqual(false, tenorMid.Equals((object)tenorLow));
            Assert.AreEqual(false, tenorHigh.Equals((object)tenorLow));
            Assert.AreEqual(false, tenorHigh.Equals((object)tenorMid));

            Assert.AreEqual(false, tenorMid.Equals(null));
            Assert.AreEqual(false, tenorHigh.Equals(null));
            Assert.AreEqual(false, tenorHigh.Equals(null));

        }

        [TestMethod]
        public void TestParse_Equals_Positive()
        {
           Tenor tenorLow = new Tenor(0, 0, 0, 1);
           Tenor tenorMid = new Tenor(0, 0, 1, 1);
           Tenor tenorMid2 = new Tenor(0, 0, 0, 8);
           Tenor tenorHigh = new Tenor(0, 1, 1, 1);

            Assert.AreEqual(false,Tenor.Equals(tenorLow, tenorMid));
            Assert.AreEqual(false,Tenor.Equals(tenorLow, tenorHigh));
            Assert.AreEqual(false,Tenor.Equals(tenorMid, tenorHigh));

            Assert.AreEqual(true,Tenor.Equals(tenorLow, tenorLow));
            Assert.AreEqual(true,Tenor.Equals(tenorMid, tenorMid));
            Assert.AreEqual(true,Tenor.Equals(tenorMid, tenorMid2));
            Assert.AreEqual(true,Tenor.Equals(tenorHigh, tenorHigh));

            Assert.AreEqual(false,Tenor.Equals(tenorMid, tenorLow));
            Assert.AreEqual(false,Tenor.Equals(tenorHigh, tenorLow));
            Assert.AreEqual(false,Tenor.Equals(tenorHigh, tenorMid));
        }

        [TestMethod]
        public void TestParse_GetHashCode_Positive()
        {
            var tenorLow = new Tenor(0, 0, 0, 1).GetHashCode();
            var tenorMid = new Tenor(0, 0, 1, 1).GetHashCode();
            var tenorMid2 = new Tenor(0, 0, 0, 8).GetHashCode();
            var tenorHigh = new Tenor(0, 1, 1, 1).GetHashCode();

            Assert.AreNotSame(tenorLow,tenorMid);
            Assert.AreNotSame(tenorLow,tenorMid2);
            Assert.AreNotSame(tenorMid,tenorMid2);
            Assert.AreNotSame(tenorLow,tenorHigh);
            Assert.AreNotSame(tenorMid,tenorHigh);
            
        }

        [TestMethod]
        public void TestParse_ToString_Positive()
        {
            var tenorEmpty = new Tenor().ToString();
            var tenorLow = new Tenor(0, 0, 0, 1).ToString();
            var tenorMid = new Tenor(0, 0, 1, 1).ToString();
            var tenorMid2 = new Tenor(0, 0, 0, 8).ToString();
            var tenorHigh = new Tenor(1, 1, 1, 1).ToString();

            Assert.AreEqual("", tenorEmpty);
            Assert.AreEqual("1d", tenorLow);
            Assert.AreEqual("1w1d", tenorMid);
            Assert.AreEqual("8d", tenorMid2);
            Assert.AreEqual("1y1m1w1d", tenorHigh);
        }

    }
}
