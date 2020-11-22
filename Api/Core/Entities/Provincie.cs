using System;
using Core.ValueObjects;

namespace Core.Entities
{
    public class Provincie : BaseEntity
    {
        public Provincie(Name name, Hoofdstad hoofdstad, Oppervlakte oppervlakte)
            : base(Guid.NewGuid())
        {
            Name = name;
            Hoofdstad = hoofdstad;
            Oppervlakte = oppervlakte;
        }

        public Name Name { get; set; }

        public Hoofdstad Hoofdstad { get; set; }

        public Oppervlakte Oppervlakte { get; set; }
    }
}
