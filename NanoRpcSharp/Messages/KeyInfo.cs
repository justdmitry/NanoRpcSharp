namespace NanoRpcSharp.Messages
{
    public class KeyInfo
    {
        public Hex32 Private { get; set; }

        public Hex32 Public { get; set; }

        public Account Account { get; set; }
    }
}
