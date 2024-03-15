using System;


namespace Class_Members
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new MyList<string>();
            EventExample ex = new();
            names.Changed += ex.ListChanged;
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            Console.WriteLine(EventExample.NumberOfChanges);
            Console.ReadKey();
        }
    }

    class EventExample
    { 

        public static int NumberOfChanges;
        public void ListChanged(object source , EventArgs e)
        {
            NumberOfChanges++;
        }
    }

    //Properties => is a way of adding security to your code...it is something between a field and a method
    //sometimes we need to access and read the data and put limits on changing the data (so we can't just change the access
    //modifier to private -> we can't get the value and read and vice versa)
    class MyList<T>
    {
        int _count;
        T[] _items;
        const int DefaultCapacity = 4;
        //Constructor
        public MyList(int capacity = DefaultCapacity)
        {
            _items =new T[capacity];
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
                if (!Object.Equals(_items[index] , value))
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
            Changed?.Invoke(this , EventArgs.Empty);
        }

        public override bool Equals(object? obj)
        {
            return Equals(this, obj as MyList<T>);
        }

        static bool Equals(MyList<T> a , MyList<T> b)
        {
            if (object.ReferenceEquals(a, null) == true) return object.ReferenceEquals(b, null);
            if (object.ReferenceEquals(b, null) || a._count != b._count) return false;
            for(int i = 0; i < a._count; i++)
            {
                if (!Object.Equals(a._items[i], b._items[i])) return false;
               
            }
            return true;

        }

        public static bool operator ==(MyList<T> a, MyList<T> b) => Equals(a, b);
        public static bool operator !=(MyList<T> a, MyList<T> b) => !Equals(a, b);

    }

}