namespace NanoRpcSharp
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Account number/identifier
    /// </summary>
    [TypeConverter(typeof(AccountConverter))]
    public struct Account : IEquatable<Account>, IComparable<Account>
    {
        private static readonly Regex Pattern = new Regex(@"^ (xrb|nano|ban) _ [\w\d]{60} $", RegexOptions.IgnorePatternWhitespace);

        private string value;

        public Account(string value)
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

        public static implicit operator Account(string s)
            => new Account(s);

        public static implicit operator string(Account path)
            => path.ToString();

        public static bool operator ==(Account left, Account right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Account left, Account right)
        {
            return !left.Equals(right);
        }

        public bool Equals(Account other)
        {
            return value.Equals(other.value, StringComparison.OrdinalIgnoreCase);
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

            return obj is Account ps && Equals(ps);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public int CompareTo(Account other)
        {
            return string.CompareOrdinal(this.value, other.value);
        }
    }

    internal class AccountConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string)
            ? true
            : base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            => value is string
            ? new Account((string)value)
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
