// Copyright © Alexander Paskhin 2018-2020. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Finance.Period
{
    /// <summary>
    /// Tokenizer a <c>string</c> into <see cref="TenorSegment"/>s.
    /// </summary>
    public readonly struct TenorSegmentTokenizer : IEnumerable<(TenorSegment, char)>
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

        IEnumerator<(TenorSegment, char)> IEnumerable<(TenorSegment, char)>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public struct Enumerator : IEnumerator<(TenorSegment, char)>
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
                Current = default((TenorSegment, char));
                _index = 0;
            }

            public (TenorSegment, char) Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                char sep = default(char);
                if (!_value.HasValue || _index >= _value.Length)
                {
                    Current = default((TenorSegment, char));
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

                Current = (_value.Subsegment(_index, next - _index), sep);
                _index = next + 1;

                return true;
            }

            public void Reset()
            {
                Current = default((TenorSegment, char));
                _index = 0;
            }
        }
    }
}
