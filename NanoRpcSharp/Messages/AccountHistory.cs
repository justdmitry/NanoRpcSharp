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

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public Account? Destination { get; set; }

            /// <summary>
            /// Only for RAW request.
            /// </summary>
            public BigInteger? Balance { get; set; }

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
