using System;
using System.Text;

internal static class Defaults
{
    public static readonly Encoding UnicodeEncoding = BitConverter.IsLittleEndian ? Encoding.Unicode : Encoding.BigEndianUnicode;
}

