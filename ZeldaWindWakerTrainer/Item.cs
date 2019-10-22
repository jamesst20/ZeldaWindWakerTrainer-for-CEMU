using System.Collections.Generic;

namespace ZeldaWindWakerTrainer
{
    internal struct Item
    {
        public static readonly IList<Item> Instances = new List<Item>();

        public int Id { get; }
        public string Name { get; }

        public Item(string name, int id)
        {
            Name = name;
            Id = id;

            Instances.Add(this);
        }
    }
}
