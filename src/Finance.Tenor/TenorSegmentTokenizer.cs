// Copyright © Alexander Paskhin 2018. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Finance.Period
{
    /// <summary>
    /// Tokenizer a <c>string</c> into <see cref="TenorSegment"/>s.
    /// </summary>
#if NET452 || NET462
    public readonly struct TenorSegmentTokenizer : IEnumerable<Tuple<TenorSegment, char>>
#else
    public readonly struct TenorSegmentTokenizer : IEnumerable<(TenorSegment, char)>
#endif
    {
        private readonly TenorSegment _value;
        private readonly char[] _separators;

        /// <summary>
        /// Initializes a new instance of <see cref="TenorSegmentTokenizer"/>.
        /// </summary>
        /// <param name="value">The <c>string</c> to tokenize.</param>
        /// <param name="separators">The characters to tokenize by.</param>
        public TenorSegmentTokenizer(string value, char[] separators)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (separators == null)
            {
                throw new ArgumentNullException(nameof(separators));
            }

            _value = value;
            _separators = separators;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TenorSegmentTokenizer"/>.
        /// </summary>
        /// <param name="value">The <c>TenorSegment</c> to tokenize.</param>
        /// <param name="separators">The characters to tokenize by.</param>
        public TenorSegmentTokenizer(TenorSegment value, char[] separators)
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (separators == null)
            {
                throw new ArgumentNullException(nameof(separators));
            }

            _value = value;
            _separators = separators;
        }

        public Enumerator GetEnumerator() => new Enumerator(in _value, _separators);

#if NET452 || NET462
        IEnumerator<Tuple<TenorSegment, char>> IEnumerable<Tuple<TenorSegment, char>>.GetEnumerator() => GetEnumerator();
#else
        IEnumerator<(TenorSegment, char)> IEnumerable<(TenorSegment, char)>.GetEnumerator() => GetEnumerator();
#endif
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

#if NET452 || NET462
        public struct Enumerator : IEnumerator<Tuple<TenorSegment, char>>
#else
        public struct Enumerator : IEnumerator<(TenorSegment, char)>
#endif
        {
            private readonly TenorSegment _value;
            private readonly char[] _separators;
            private int _index;

            internal Enumerator(in TenorSegment value, char[] separators)
            {
                _value = value;
                _separators = separators;
                Current = default;
                _index = 0;
            }

            public Enumerator(ref TenorSegmentTokenizer tokenizer)
            {
                _value = tokenizer._value;
                _separators = tokenizer._separators;
#if NET452 || NET462
                Current = default(Tuple<TenorSegment, char>);
#else
                Current = default((TenorSegment, char));
#endif
                _index = 0;
            }

#if NET452 || NET462
            public Tuple<TenorSegment, char> Current { get; private set; }
#else
            public (TenorSegment, char) Current { get; private set; }
#endif

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                char sep = default(char);
                if (!_value.HasValue || _index >= _value.Length)
                {
#if NET452 || NET462
                    Current = default(Tuple<TenorSegment, char>);
#else
                    Current = default((TenorSegment, char));
#endif
                    return false;
                }

                var next = _value.IndexOfAny(_separators, _index);
                if (next == -1)
                {
                    // No separator found. Consume the remainder of the string.
                    next = _value.Length;
                }
                else
                {
                    sep = _value[next];
                }

#if NET452 || NET462
                Current = new Tuple<TenorSegment, char>(_value.Subsegment(_index, next - _index),sep);
#else
                Current = (_value.Subsegment(_index, next - _index), sep);
#endif
                _index = next + 1;

                return true;
            }

            public void Reset()
            {
#if NET452 || NET462
                Current = default(Tuple<TenorSegment, char>);
#else
                Current = default((TenorSegment, char));
#endif
                _index = 0;
            }
        }
    }
}
