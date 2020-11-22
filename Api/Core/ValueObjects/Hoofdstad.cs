namespace Core.ValueObjects
{
    public class Hoofdstad
    {
        public Hoofdstad(string naam)
        {
            Naam = naam;
        }

        public string Naam { get; set; }
    }
}
