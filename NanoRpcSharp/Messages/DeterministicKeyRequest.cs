namespace NanoRpcSharp.Messages
{
    public class DeterministicKeyRequest : RequestBase<KeyInfo>
    {
        public DeterministicKeyRequest(Hex32 seed, uint index)
            : base("deterministic_key")
        {
            this.Index = (int)index;
        }

        public Hex32 Seed { get; set; }

        public int Index { get; set; }
    }
}
