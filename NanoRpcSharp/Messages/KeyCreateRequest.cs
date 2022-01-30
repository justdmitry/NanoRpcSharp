namespace NanoRpcSharp.Messages
{
    public class KeyCreateRequest : RequestBase<KeyInfo>
    {
        public KeyCreateRequest()
            : base("key_create")
        {
            // Nothing
        }
    }
}
