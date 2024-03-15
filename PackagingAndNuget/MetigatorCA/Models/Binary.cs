namespace MetigatorCA.Models
{
    public class Binary : Base 
    {
        public Binary(string value) 
        {
            value.Gaurd("01", NumberBaseSystem.Binary);
            Value = value;
        }
    }
}
