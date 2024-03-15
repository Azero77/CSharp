using MetigatorCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetigatorCA
{
    public static class NumberExtensions
    {
        public static void Gaurd(this string Value, string AllowedCharacters , NumberBaseSystem NumberBase) 
        {
            foreach (var ch in Value) 
            {
                if (!AllowedCharacters.Contains(ch))
                {
                    throw new InvalidDataException($"Can't Convert {Value} to {NumberBase}");
                }
            }
        }

        public static string To<T>(this T source, NumberBaseSystem toBase) where T:Base
        {
            NumberBaseSystem fromBase;
            switch (source)
            {
                case Binary b:
                    fromBase = NumberBaseSystem.Binary;
                    break;
                case Octal o:
                    fromBase = NumberBaseSystem.Octal;
                    break;
                case DecimalSystem d:
                    fromBase = NumberBaseSystem.Decimal;
                    break;
                case HexaDecimal h:
                    fromBase = NumberBaseSystem.HexaDecimal;
                    break;
                default:
                    fromBase = NumberBaseSystem.Decimal;
                    break;
            }
            var tmp = Convert.ToInt32(source.Value,(int) fromBase);
            var result = Convert.ToString(tmp , (int) toBase);

            return result;
        }
    }
}
