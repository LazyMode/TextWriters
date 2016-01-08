using System;
using System.IO;

namespace TextWriters
{
    public class WrapperLineWriter : LineWriter
    {
        private readonly TextWriter _BaseWriter;
        private readonly bool _CloseBase;

        public WrapperLineWriter(TextWriter baseWriter, bool leaveOpen = false, IFormatProvider formatProvider = null)
            : base(formatProvider)
        {
            _BaseWriter = baseWriter;
            _CloseBase = !leaveOpen;
        }

        protected override void FlushLine(string s)
            => _BaseWriter?.WriteLine(s);

        protected override void Dispose(bool disposing)
        {
            if (disposing && _CloseBase)
                _BaseWriter?.Dispose();

            base.Dispose(disposing);
        }
    }
}
