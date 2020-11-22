namespace Core.ValueObjects
{
    public class Name
    {
        public Name(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
