using System;

public abstract class PrefixedLineWriter : LineWriter
{
    private readonly string _Prefix;

    protected PrefixedLineWriter(string prefix, IFormatProvider formatProvider)
        : base(formatProvider)
    {
        _Prefix = prefix;
    }

    protected override string DecorateLine(string source)
        => _Prefix + source;
}
