namespace Structs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Both Structs and Classes are UserDefinedTypes
            //Both can have Constructors
            //structs can't have parameterless Constuct unlike class
            //both can have fields and access modifiers to them
            //structs can't have Field Initializer
            //structs support properties and methods and indexers , events , operator overloading
            //can't have finalizers and destructors
            //can't support inheritance(can only support interfaces)
            //implicitly inherit object class
            //value type (stores in the stack)
            //stack is faster than the heap
            //new() is mandatory
            //structs are immutable unlike classes
            //structs can have readonly members that can be initialized by ctor or in declaring the structs and you can't initialize the value to an object by obj.a = 3;
            //all value types int - long are structsss
            var S = new Student { Id = 4};
            var message = new Message();
            S.Changed += message.Send;
            S.Id = 5;
            //datetime is a struct
            DateTime d = new DateTime();
            Console.WriteLine(S[5]);
            Console.ReadKey();

        }
    }
    struct Student
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnChanged();
            }
        }
        public int this[int i]
        {
            get { return id * i; }

        }

        public event EventHandler Changed;

        public void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }

    class Message
    {
        public void Send(object? sender , EventArgs e)
        {
            Console.WriteLine("Message Send!!!");
        }
    }
}
