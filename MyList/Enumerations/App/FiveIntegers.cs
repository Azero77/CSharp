using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class FiveIntegers : IEnumerable
    {
        private int[] _items;

        public FiveIntegers(int n1 , int n2 , int n3  , int n4 , int n5) 
        {
            _items = [n1, n2, n3, n4, n5];
        }


        public IEnumerator GetEnumerator()
        {
            foreach(var item in _items)
            {
                yield return item;
            }
        }

        public IEnumerator GetEnumerator() => new Enumerator(this);

        class Enumerator : IEnumerator
        {

            FiveIntegers _integers;
            int CurrentIndex = -1;
            public Enumerator(FiveIntegers items)
            {
                _integers = items;
            }


            public object Current
            {
                get
                {
                    if (CurrentIndex == -1) throw new InvalidOperationException("Iteration has not started");
                    return _integers._items[CurrentIndex];
                }
            }

            public bool MoveNext()
            {
                if (CurrentIndex >= _integers._items.Length) throw new InvalidOperationException("Iteration has ended");
                return ++CurrentIndex < _integers._items.Length;

            }

            public void Reset() => CurrentIndex = -1;

        }


    }
}
