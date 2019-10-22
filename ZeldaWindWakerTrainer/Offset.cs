namespace ZeldaWindWakerTrainer
{
    internal struct Offset
    {
        public long Address { get; }
        public int Size { get; }
        public MemoryType MemoryType { get; }

        public Offset(long address, int size, MemoryType memoryType)
        {
            Address = address;
            Size = size;
            MemoryType = memoryType;
        }
    }
}
