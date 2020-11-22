using System;

namespace Core.Entities
{
    public class Gemeente : BaseEntity
    {
        public Gemeente()
            : base(Guid.NewGuid())
        {
        }

        public string Name { get; set; }

        public Provincie Provincie { get; set; }

        public int AantalInwoners { get; set; }
    }
}
