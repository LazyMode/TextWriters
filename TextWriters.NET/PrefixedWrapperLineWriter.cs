using System;
using System.IO;

namespace TextWriters
{
    public class PrefixedWrapperLineWriter : WrapperLineWriter
    {
        private readonly string _Prefix;

        public PrefixedWrapperLineWriter(TextWriter baseWriter, string prefix, bool leaveOpen = false, IFormatProvider formatProvider = null)
            : base(baseWriter, leaveOpen, formatProvider)
        {
            _Prefix = prefix;
        }

        protected override string DecorateLine(string source)
            => _Prefix + source;
    }
}