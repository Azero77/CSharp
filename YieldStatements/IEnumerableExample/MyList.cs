using System.Collections;



namespace IEnumerableExample
{
    class MyList<T> : IEnumerable
    {
        int _count;
        T[] _items;
        const int DefaultCapacity = 4;
        //Constructor
        public MyList(int capacity = DefaultCapacity)
        {
            _items = new T[capacity];
        }

        public int Count => _count;


        //Property
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value <= _count) value = Count;
                else
                {
                    var newItems = new T[value];
                    Array.Copy(_items, 0, newItems, 0, _items.Length);
                    _items = newItems;
                }
            }
        }

        //indexer
        public T this[int index]
        {
            get => _items[index];
            set
            {
                if (!Object.Equals(_items[index], value))
                {
                    _items[index] = value;
                    OnChanged();
                }
            }
        }

        public void Add(T item)
        {
            if (_count == this.Capacity) this.Capacity *= 2;
            _items[_count] = item;
            _count++;
            OnChanged();
        }

        //Events
        public event EventHandler Changed;
        protected virtual void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public override bool Equals(object? obj)
        {
            return Equals(this, obj as MyList<T>);
        }

        static bool Equals(MyList<T> a, MyList<T> b)
        {
            if (object.ReferenceEquals(a, null) == true) return object.ReferenceEquals(b, null);
            if (object.ReferenceEquals(b, null) || a._count != b._count) return false;
            for (int i = 0; i < a._count; i++)
            {
                if (!Object.Equals(a._items[i], b._items[i])) return false;

            }
            return true;

        }

        public static bool operator ==(MyList<T> a, MyList<T> b) => Equals(a, b);
        public static bool operator !=(MyList<T> a, MyList<T> b) => !Equals(a, b);

        public IEnumerator GetEnumerator()
        {
                foreach (var item in _items) 
                {
                    yield return item;
                }       
         }

        /*class MyEnumerator<T> : IEnumerator
        {
            public MyEnumerator(MyList<T> items)
            {
                list = items;
            }
            public object Current
            {
                get
                {
                    if (CurrentIndex == -1) throw new InvalidDataException();
                    if (CurrentIndex < list.Count) return list[CurrentIndex];
                    else { throw new InvalidDataException(); }
                }
            }

            public MyList<T> list;
            private int CurrentIndex = -1;

            public bool MoveNext()
            {
                return CurrentIndex++ < list.Count - 1;
            }

            public void Reset()
            {
                CurrentIndex = -1;
            }

        }*/


    }



    
}
