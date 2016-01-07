using System;

namespace TextWriters
{
    public sealed class ActionLineWriter : LineWriter
    {
        private readonly Action<string> _Action;

        public ActionLineWriter(Action<string> action, IFormatProvider formatProvider = null)
            : base(formatProvider)
        {
            _Action = action;
        }

        protected override void FlushLine(string s)
            => _Action?.Invoke(s);
    }
}
