namespace NanoRpcSharp.Messages
{
    public class BlockCountByType
    {
        public long Send { get; set; }

        public long Receive { get; set; }

        public long Open { get; set; }

        public long Change { get; set; }
    }
}
