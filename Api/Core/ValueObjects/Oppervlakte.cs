namespace Core.ValueObjects
{
    public class Oppervlakte
    {
        public Oppervlakte(double value, OppervlakteEenheid eenheid)
        {
            Value = value;
            Eenheid = eenheid;
        }

        public double Value { get; set; }

        public OppervlakteEenheid Eenheid { get; }
    }
}
