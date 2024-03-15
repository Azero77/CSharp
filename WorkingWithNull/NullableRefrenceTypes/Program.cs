namespace NullableRefrenceTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //value has some default values like:
            //int  = 0
            //decimal = 0.0
            //bool = false;
            //but the default value of refrence is null
            //starting from c# 6 ,<Nullable> in csproj has been added
            //it allows you to make use of null refrence types
            int a = default;
            int? b = default;
            Console.WriteLine(a == b); //false;
            string? c = default;
            Console.WriteLine(c is null); //true
            Console.WriteLine(GetLength(c));

        }

        static int GetLength(string? a)
        {
            if (a is null)
                return 0;
            return a.Length;
        }
    }
}
