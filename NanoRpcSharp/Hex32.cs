namespace NanoRpcSharp
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 32 byte value, usually represented as a 64 character, uppercase hexadecimal string(0-9A-F).
    /// </summary>
    [TypeConverter(typeof(Hex32Converter))]
    public struct Hex32 : IEquatable<Hex32>, IComparable<Hex32>
    {
        private static readonly Regex Pattern = new Regex("^ [0-9A-F]{64} $", RegexOptions.IgnorePatternWhitespace);

        private string value;

        public Hex32(string value)
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

        public Hex32(byte[] value)
        {
            if (value.Length != 32)
            {
                throw new ArgumentException(nameof(value), "Need 32 bytes");
            }

            this.value = BitConverter.ToString(value).Replace("-", null);
        }

        public static implicit operator Hex32(string s)
            => new Hex32(s);

        public static implicit operator string(Hex32 path)
            => path.ToString();

        public static bool operator ==(Hex32 left, Hex32 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Hex32 left, Hex32 right)
        {
            return !left.Equals(right);
        }

        public bool Equals(Hex32 other)
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

            return obj is Hex32 ps && Equals(ps);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public int CompareTo(Hex32 other)
        {
            return string.CompareOrdinal(this.value, other.value);
        }
    }

    internal class Hex32Converter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string)
            ? true
            : base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            => value is string
            ? new Hex32((string)value)
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
