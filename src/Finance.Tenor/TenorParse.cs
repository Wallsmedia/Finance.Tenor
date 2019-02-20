// Copyright © Alexander Paskhin 2018. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using System;

namespace Finance.Period
{

    /// <summary>
    /// Internal Tenor parser.
    /// </summary>
    public partial struct Tenor 
    {
        private const char PatternDay = 'd';
        private const char PatternWeek = 'w';
        private const char PatternMonth = 'm';
        private const char PatternYear = 'y';
        private const char PatternDayUp = 'D';
        private const char PatternWeekUp = 'W';
        private const char PatternMonthUp = 'M';
        private const char PatternYearUp = 'Y';

        private static readonly char[] Separators = new char[] { PatternDay, PatternWeek, PatternMonth, PatternYear, PatternDayUp, PatternWeekUp, PatternMonthUp, PatternYearUp };

        /// <summary>
        /// Parses the tenor string into a <see cref="FormatException.Tenor"/> instance.
        /// </summary>
        /// <param name="tenor">The input non empty string</param>
        /// <exception cref="Finance.Period">The input string is empty or has an invalid format.</exception>
        /// <returns>The <see cref="Period.Tenor"/> instance.</returns>
        public static Period.Tenor Parse(string tenor)
        {
            if (TryParse(tenor, out var result))
            {
                return result;
            }
            throw new FormatException("Cannot parse the tenor");
        }

        /// <summary>
        /// Parses the tenor string into a <see cref="Period.Tenor"/> instance.
        /// </summary>
        /// <param name="tenor">The input non empty string</param>
        /// <param name="result">The result <see cref="Period.Tenor"/> instance. </param>
        /// <returns>True if it is parsed with success.</returns>
        public static bool TryParse(string tenor, out Period.Tenor result)
        {
            var wrapper = new TenorSegment(tenor);
            return TryParse(ref wrapper, out result);
        }

        /// <summary>
        /// Parses the tenor string into a <see cref="Period.Tenor"/> instance.
        /// </summary>
        /// <param name="tenor">The input non empty string segment.</param>
        /// <param name="result">The result <see cref="Period.Tenor"/> instance. </param>
        /// <returns>True if it is parsed with success.</returns>
        public static bool TryParse(ref TenorSegment tenor, out Period.Tenor result)
        {
            result = default(Period.Tenor);

            if (!tenor.HasValue || tenor.Length == 0)
            {
                return false;
            }

            int? years = null;
            int? weeks = null;
            int? months = null;
            int? days = null;
            var flatList = tenor.Split(Separators);

            foreach (var item in flatList)
            {

                if (TryParse(item.Item1, out int number))
                {
                    switch (item.Item2)
                    {
                        case PatternDay:
                        case PatternDayUp:
                            if (days.HasValue)
                            {
                                return false;
                            }
                            days = number;
                            break;
                        case PatternWeek:
                        case PatternWeekUp:
                            if (weeks.HasValue)
                            {
                                return false;
                            }
                            weeks = number;
                            break;
                        case PatternMonth:
                        case PatternMonthUp:
                            if (months.HasValue)
                            {
                                return false;
                            }
                            months = number;
                            break;
                        case PatternYear:
                        case PatternYearUp:
                            if (years.HasValue)
                            {
                                return false;
                            }
                            years = number;
                            break;
                        default:
                            return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            result = new Period.Tenor(years ?? 0, months ?? 0, weeks ?? 0, days ?? 0);
            return true;
        }

        static bool TryParse(TenorSegment segment, out Int32 result)
        {
            result = 0;
            if (!segment.HasValue || segment.Length == 0)
            {
                return false;
            }

            long exp = result = 0;
            for (int i = 0; i < segment.Length; i++)
            {
                var ch = segment[i];
                if (ch >= '0' && ch <= '9')
                {
                    exp = exp * 10 + (ch - '0');
                    if (exp > int.MaxValue)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            result = (int)exp;
            return true;
        }

    }
}
