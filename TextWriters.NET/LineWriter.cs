using System;
using System.IO;
using System.Text;

public abstract class LineWriter : TextWriter
{
    private bool _CRFound = false;
    private readonly StringBuilder _Buffer = new StringBuilder();

    protected LineWriter(IFormatProvider formatProvider)
        : base(formatProvider)
    { }

    protected virtual string DecorateLine(string source) => source;
    protected abstract void FlushLine(string line);

    private void FlushLine()
    {
        FlushLine(DecorateLine(_Buffer.ToString()));
        _Buffer.Clear();
    }

    public override void Write(char value)
    {
        switch (value)
        {
            case '\n':
                if (_CRFound)
                {
                    _CRFound = false;
                    return;
                }
                break;
            case '\r':
                _CRFound = true;
                break;
            default:
                _CRFound = false;
                _Buffer.Append(value);
                return;
        }

        FlushLine();
    }

    public override Encoding Encoding => Encoding.Unicode;
}
