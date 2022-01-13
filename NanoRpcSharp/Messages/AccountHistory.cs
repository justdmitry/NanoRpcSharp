namespace NanoRpcSharp.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class AccountHistory
    {
        public List<Item> History { get; set; }

        public Hex32? Previous { get; set; }

        public class Item
        {
            public Hex32 Hash { get; set; }

            public string Type { get; set; }

            public Account Account { get; set; }

            public BigInteger Amount { get; set; }

            public DateTimeOffset LocalTimestamp { get; set; }

            public int Height { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public Account? Representative { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            [Obsolete("Removed from docs")]
            public Account? Destination { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public Hex32? Link { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public BigInteger? Balance { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public Hex32? Previous { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public string Subtype { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public string Work { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public string Signature { get; set; }
        }
    }
}
