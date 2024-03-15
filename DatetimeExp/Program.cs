namespace DatetimeExp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dt = DateTime.Now;

            DateTime dt1 = new DateTime(2012,4,21);
            Console.WriteLine(dt);
            TimeSpan time = DateTime.Now - dt1;
            Console.WriteLine(time.ToString());
            Console.WriteLine(dt1.Add(time));
            Console.WriteLine(")))))))))))))))))))))))))((((((((((((((((((((((((((");
            DateTimeOffset dt2 = DateTimeOffset.Now;
            Console.WriteLine(dt2.ToDateTime().Hour);
            Console.WriteLine(DateTImeOffSetExtension.ToDateTime(dt2).Hour);
        }
    }
}
