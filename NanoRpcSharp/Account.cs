namespace NanoRpcSharp
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Blake2Sharp;

    /// <summary>
    /// Account number/identifier.
    /// </summary>
    [TypeConverter(typeof(AccountConverter))]
    public struct Account : IEquatable<Account>, IComparable<Account>
    {
        private const string EmptyAddress = "xrb_1111111111111111111111111111111111111111111111111111hifc8npp";

        private static readonly Regex Pattern = new Regex($"^ (xrb|nano|ban) _ [{NanoBase32Encoding.Alphabet}]{{60}} $", RegexOptions.IgnorePatternWhitespace);

        private static readonly Blake2BConfig ChecksumBlack2bConfig = new Blake2BConfig() { OutputSizeInBytes = 5 };

        private readonly string value;

        private Account(string value)
        {
            this.value = value;
        }

        public static Account Empty { get; } = new Account(EmptyAddress);

        public static implicit operator Account(string s)
            => Account.Parse(s);

        public static implicit operator string(Account account)
            => account.ToString();

        public static bool operator ==(Account left, Account right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Account left, Account right)
        {
            return !left.Equals(right);
        }

        public static Account Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!TryParse(value, out var account))
            {
                throw new ArgumentException(nameof(value), "Not a valid address");
            }

            return account;
        }

        public static bool TryParse(string value, out Account account)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                account = Empty;
                return false;
            }

            value = value.ToLowerInvariant();

            if (!Pattern.IsMatch(value))
            {
                account = Empty;
                return false;
            }

            var key = value.AsSpan(value.Length - 60, 52);
            var checksum = value.AsSpan(value.Length - 8, 8);

            var pubKeyBytes = NanoBase32Encoding.Base32ToBytes(key);
            var checksumBytes = Blake2B.ComputeHash(pubKeyBytes.ToArray(), ChecksumBlack2bConfig);
            checksumBytes.Reverse();
            var validChecksum = NanoBase32Encoding.BytesToBase32(checksumBytes);

            if (!checksum.SequenceEqual(validChecksum.AsSpan()))
            {
                account = Empty;
                return false;
            }

            account = new Account(value);
            return true;
        }

        public bool Equals(Account other)
        {
            return string.Equals(this.value ?? EmptyAddress, other.value ?? EmptyAddress, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return value ?? EmptyAddress;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is Account ps && Equals(ps);
        }

        public override int GetHashCode()
        {
            return (value ?? EmptyAddress).GetHashCode();
        }

        public int CompareTo(Account other)
        {
            return string.CompareOrdinal(this.value ?? EmptyAddress, other.value ?? EmptyAddress);
        }

        public bool IsEmpty()
        {
            return CompareTo(Empty) == 0;
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
            ? Account.Parse((string)value)
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
