using System;

namespace TextWriters
{
    public sealed class EventLineWriter : LineWriter
    {
        public event Action<string> FlushLineEvent;

        public EventLineWriter(IFormatProvider formatProvider = null) 
            : base(formatProvider)
        { }

        protected override void FlushLine(string s)
            => FlushLineEvent?.Invoke(s);
    }
}
