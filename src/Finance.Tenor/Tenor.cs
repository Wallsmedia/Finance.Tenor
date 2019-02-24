// Copyright © Alexander Paskhin 2018. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace Finance.Period
{

    /// <summary>
    /// Represents the unit of frequency or duration.
    /// </summary>
    [DebuggerDisplay("T:[{Years}y{Months}m{Weeks}w{Days}d]")]
    public partial struct Tenor : IEquatable<Tenor>, IComparable<Tenor>, IComparable
    {
        private readonly int _totalDays;

        /// <summary>
        ///  Creates a new instance of an Tenor.
        /// </summary>
        /// <param name="years">The number of years</param>
        /// <param name="months">The number of months</param>
        /// <param name="weeks">The number of weeks</param>
        /// <param name="days">The number of days</param>
        public Tenor(int years, int months, int weeks, int days)
        {
            if (years < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(years));
            }
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(months));
            }
            if (weeks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weeks));
            }
            if (days < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(days));
            }

            Years = years;
            Months = months;
            Weeks = weeks;
            Days = days;
            // calculations for comparison reasons only
            _totalDays = years * 360 + months * 30 + weeks * 7 + days;
        }

        /// <summary>
        /// Gets the number of years
        /// </summary>
        public int Years { get; }

        /// <summary>
        /// Gets the number of weeks
        /// </summary>
        public int Weeks { get; }

        /// <summary>
        /// Gets the number of months
        /// </summary>
        public int Months { get; }

        /// <summary>
        /// Gets the number of days
        /// </summary>
        public int Days { get; }

        /// <summary>
        /// Compares two Tenor values, returning an integer that indicates
        /// their relationship.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static int Compare(Tenor t1, Tenor t2)
        {
            // NOTE: Cannot use return (_value - value) as this causes a wrap
            // around in cases where _value - value > MaxValue.
            if (t1._totalDays > t2._totalDays) return 1;
            if (t1._totalDays < t2._totalDays) return -1;
            return 0;
        }

        /// <summary>
        /// Compares this Tenor to an object value, returning an integer that indicates
        /// their relationship.
        /// </summary>
        /// <param name="value">The Object to compare</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(Object value)
        {
            if (value == null) return 1;
            if (!(value is Tenor))
                throw new ArgumentException("Must Be Tenor");
            long t = ((Tenor)value)._totalDays;
            // NOTE: Cannot use return (_value - value) as this causes a wrap
            // around in cases where _value - value > MaxValue.
            if (_totalDays > t) return 1;
            if (_totalDays < t) return -1;
            return 0;
        }

        /// <summary>
        /// Compares this Tenor to anther Tenor value, returning an integer that indicates
        /// their relationship.
        /// </summary>
        /// <param name="value">The Tenor to compare</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(Tenor value)
        {
            int t = value._totalDays;
            // NOTE: Cannot use return (_value - value) as this causes a wrap
            // around in cases where _value - value > MaxValue.
            if (_totalDays > t) return 1;
            if (_totalDays < t) return -1;
            return 0;
        }

        /// <summary>
        /// Returns a boolean indicating if the passed tenor is Equal to this.
        /// </summary>
        /// <param name="other">The tenor.</param>
        /// <returns>Returns true if equal.</returns>
        public bool Equals(Tenor other)
        {
            return _totalDays == other._totalDays;
        }

        /// <summary>
        /// Returns a boolean indicating if the passed object is Equal to this.
        /// </summary>
        /// <param name="value">The object.</param>
        /// <returns>Returns true if equal.</returns>
        public override bool Equals(Object value)
        {
            if (value is Tenor tenor)
            {
                return _totalDays == tenor._totalDays;
            }
            return false;
        }

        /// <summary>
        /// Provides a hash code for this object.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return _totalDays.GetHashCode() ^ Years.GetHashCode() ^ Months.GetHashCode() ^ Weeks.GetHashCode() ^ Days.GetHashCode();
        }

        /// <summary>
        /// Returns a boolean indicating if the passed in object obj is Equal to this.
        /// </summary>
        /// <param name="t1">The Tenor</param>
        /// <param name="t2">The Tenor</param>
        /// <returns>Returns true if equal.</returns>
        public static bool Equals(Tenor t1, Tenor t2)
        {
            return t1._totalDays == t2._totalDays;
        }

        /// <summary>
        /// Returns a String represented the Tenor.
        /// </summary>
        /// <returns>The tenor string or empty for zero tenor.</returns>
        public override string ToString()
        {
            string tenorStr = (Years > 0 ? Years + "y" : string.Empty) + (Months > 0 ? Months + "m" : string.Empty) +
                              (Weeks > 0 ? Weeks + "w" : string.Empty) + (Days > 0 ? Days + "d" : string.Empty);
            return tenorStr;
        }

        #region Comparison Operators

        public static bool operator ==(Tenor t1, Tenor t2)
        {
            return t1._totalDays == t2._totalDays;
        }

        public static bool operator !=(Tenor t1, Tenor t2)
        {
            return t1._totalDays != t2._totalDays;
        }

        public static bool operator <(Tenor t1, Tenor t2)
        {
            return t1._totalDays < t2._totalDays;
        }

        public static bool operator <=(Tenor t1, Tenor t2)
        {
            return t1._totalDays <= t2._totalDays;
        }

        public static bool operator >(Tenor t1, Tenor t2)
        {
            return t1._totalDays > t2._totalDays;
        }

        public static bool operator >=(Tenor t1, Tenor t2)
        {
            return t1._totalDays >= t2._totalDays;
        }

        #endregion

    }
}
