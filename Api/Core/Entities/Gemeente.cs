using System;

namespace Core.Entities
{
    public class Gemeente : BaseEntity
    {
        public Gemeente(string name, Provincie provincie, int aantalInwoners)
            : base(Guid.NewGuid())
        {
            Name = name;
            Provincie = provincie;
            AantalInwoners = aantalInwoners;
        }

        public string Name { get; set; }

        public Provincie Provincie { get; set; }

        public int AantalInwoners { get; }
    }
}
