namespace MetigatorCA.Models
{
    public class Octal : Base
    {
        public Octal(string value)
        {
            value.Gaurd("01234567", NumberBaseSystem.Octal);
            Value = value;
        }
    }
}
