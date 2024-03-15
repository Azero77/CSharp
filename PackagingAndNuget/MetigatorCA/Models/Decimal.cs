namespace MetigatorCA.Models
{
    public class DecimalSystem : Base
    {
        public DecimalSystem(string value)
        {
            value.Gaurd("0123456789", NumberBaseSystem.Binary);
            Value = value;
        }
    }
}
