namespace NanoRpcSharp.Messages
{
    public class KeyExpandRequest : RequestBase<KeyInfo>
    {
        public KeyExpandRequest(Hex32 key)
            : base("key_expand")
        {
            this.Key = key;
        }

        public Hex32 Key { get; set; }
    }
}
