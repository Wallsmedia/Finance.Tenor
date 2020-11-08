// Copyright © Alexander Paskhin 2018-2020. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Finance.Period
{
    /// <summary>
    /// Finance Tenor operation extensions  
    /// </summary>
    public static class TenorExtensions
    {

        /// <summary>
        ///  Returns a new System.DateTime that adds the value of the specified Tenor
        ///  to the value of this instance.
        /// </summary>
        /// <param name="dateTime">The subject of operation.</param>
        /// <param name="tenor">The tenor value.</param>
        /// <returns>The new System.DateTime.</returns>
        public static DateTime Add(this DateTime dateTime, Tenor tenor)
        {
            dateTime = dateTime.AddYears(tenor.Years);
            dateTime = dateTime.AddMonths(tenor.Months);
            dateTime = dateTime.AddDays(tenor.Weeks * 7);
            dateTime = dateTime.AddDays(tenor.Days);
            return dateTime;
        }

        /// <summary>
        ///  Returns a new System.DateTimeOffset that adds the value of the specified Tenor
        ///  to the value of this instance.
        /// </summary>
        /// <param name="dateTimeOffset">The subject of operation.</param>
        /// <param name="tenor">The tenor value.</param>
        /// <returns>The new System.DateTimeOffset.</returns>
        public static DateTimeOffset Add(this DateTimeOffset dateTimeOffset, Tenor tenor)
        {
            dateTimeOffset = dateTimeOffset.AddYears(tenor.Years);
            dateTimeOffset = dateTimeOffset.AddMonths(tenor.Months);
            dateTimeOffset = dateTimeOffset.AddDays(tenor.Weeks * 7);
            dateTimeOffset = dateTimeOffset.AddDays(tenor.Days);
            return dateTimeOffset;
        }

        /// <summary>
        ///  Returns a new System.DateTime that subtracts the value of the specified Tenor
        ///  to the value of this instance.
        /// </summary>
        /// <param name="dateTime">The subject of operation.</param>
        /// <param name="tenor">The tenor value.</param>
        /// <returns>The new System.DateTime.</returns>
        public static DateTime Subsctract(this DateTime dateTime, Tenor tenor)
        {
            dateTime = dateTime.AddYears(-tenor.Years);
            dateTime = dateTime.AddMonths(-tenor.Months);
            dateTime = dateTime.AddDays(-tenor.Weeks * 7);
            dateTime = dateTime.AddDays(-tenor.Days);
            return dateTime;
        }

        /// <summary>
        ///  Returns a new System.DateTimeOffset that subtracts the value of the specified Tenor
        ///  to the value of this instance.
        /// </summary>
        /// <param name="dateTimeOffset">The subject of operation.</param>
        /// <param name="tenor">The tenor value.</param>
        /// <returns>The new System.DateTimeOffset.</returns>
        public static DateTimeOffset Subsctract(this DateTimeOffset dateTimeOffset, Tenor tenor)
        {
            dateTimeOffset = dateTimeOffset.AddYears(-tenor.Years);
            dateTimeOffset = dateTimeOffset.AddMonths(-tenor.Months);
            dateTimeOffset = dateTimeOffset.AddDays(-tenor.Weeks * 7);
            dateTimeOffset = dateTimeOffset.AddDays(-tenor.Days);
            return dateTimeOffset;
        }
    }
}
