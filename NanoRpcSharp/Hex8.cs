namespace NanoRpcSharp
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 8 byte value, usually represented as a 64 character, uppercase hexadecimal string(0-9A-F).
    /// </summary>
    [TypeConverter(typeof(Hex8Converter))]
    public struct Hex8 : IEquatable<Hex8>, IComparable<Hex8>
    {
        private static readonly Regex Pattern = new Regex("^ [0-9A-F]{16} $", RegexOptions.IgnorePatternWhitespace);

        private string value;

        public Hex8(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!Pattern.IsMatch(value))
            {
                throw new ArgumentException(nameof(value), "Doesn't match pattern");
            }

            this.value = value;
        }

        public Hex8(byte[] value)
        {
            if (value.Length != 8)
            {
                throw new ArgumentException(nameof(value), "Need 8 bytes");
            }

            this.value = BitConverter.ToString(value).Replace("-", null);
        }

        public static implicit operator Hex8(string s)
            => new Hex8(s);

        public static implicit operator string(Hex8 path)
            => path.ToString();

        public static bool operator ==(Hex8 left, Hex8 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Hex8 left, Hex8 right)
        {
            return !left.Equals(right);
        }

        public bool Equals(Hex8 other)
        {
            return value.Equals(other.value, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Hex8 ps && Equals(ps);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public int CompareTo(Hex8 other)
        {
            return string.CompareOrdinal(this.value, other.value);
        }
    }

    internal class Hex8Converter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string)
            ? true
            : base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            => value is string
            ? new Hex8((string)value)
            : base.ConvertFrom(context, culture, value);

        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
            => destinationType == typeof(string)
            ? value.ToString()
            : base.ConvertTo(context, culture, value, destinationType);
    }
}
