using System;

namespace Core.Entities
{
    public class Provincie : BaseEntity
    {
        public Provincie()
            : base(Guid.NewGuid())
        {
        }

        public string Name { get; set; }

        public string Hoofdstad { get; set; }

        public int OppervlakteKm2 { get; set; }
    }
}
