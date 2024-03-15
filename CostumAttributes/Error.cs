using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumAttributes
{
    internal class Error
    {
        public Error(string field, string message)
        {
            Field = field;
            Message = message;
        }

        public string Field { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Field}:{Message}";
        }

    }
}
