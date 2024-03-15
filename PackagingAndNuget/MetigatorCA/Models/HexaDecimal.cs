namespace MetigatorCA.Models
{
    public class HexaDecimal : Base
    {
        public HexaDecimal(string value)
        {
            value.Gaurd("0123456789abcdefABCDEF", NumberBaseSystem.Binary);
            Value = value;
        }
    }
}
