using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Tempreture : IComparable
    {
        private int _value;
        public int Value => _value;
        public Tempreture(int value)
        {
            _value = value;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            var temp = obj as Tempreture;
            if (temp == null) return 1;

            return this.Value.CompareTo(temp.Value);
        }
    }
}
