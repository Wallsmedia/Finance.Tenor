// Copyright © Alexander Paskhin 2018-2020. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Period.Test
{
    [TestClass]
    public class UnitTestOfOperations
    {
        [TestMethod]
        public void TestDateTime_Add_Sub_1y1m1w1d_PositiveResult()
        {
            // set
            string strtenor = "1y1m1w1d";
            Tenor tenor = Tenor.Parse(strtenor);
            var expected = DateTime.UtcNow;

            // Action
            var testdate = expected.Add(tenor);
            testdate = testdate.Subsctract(tenor);

            //Assertion
            Assert.AreEqual(expected, testdate);
        }
 
        [TestMethod]
        public void TestDateTime_OPAdd_Sub_1y1m1w1d_PositiveResult()
        {
            // set
            string strtenor = "1y1m1w1d";
            Tenor tenor = Tenor.Parse(strtenor);
            var expected = DateTime.UtcNow;

            // Action
            var testdate = expected + tenor;
            testdate = testdate - tenor;

            //Assertion
            Assert.AreEqual(expected, testdate);
        }
        
        [TestMethod]
        public void TestDateTimeOffset_Add_Sub_1y1m1w1d_PositiveResult()
        {
            // set
            string strtenor = "1y1m1w1d";
            Tenor tenor = Tenor.Parse(strtenor);
            var expected = DateTimeOffset.UtcNow;

            // Action
            var testdate = expected.Add(tenor);
            testdate = testdate.Subsctract(tenor);

            //Assertion
            Assert.AreEqual(expected, testdate);
        }
 
        [TestMethod]
        public void TestDateTimeOffset_OPAdd_Sub_1y1m1w1d_PositiveResult()
        {
            // set
            string strtenor = "1y1m1w1d";
            Tenor tenor = Tenor.Parse(strtenor);
            var expected = DateTimeOffset.UtcNow;

            // Action
            var testdate = expected + tenor;
            testdate = testdate - tenor;

            //Assertion
            Assert.AreEqual(expected, testdate);
        }

    }
}
