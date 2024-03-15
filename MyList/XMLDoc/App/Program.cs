namespace App
{
    //when we are building our program we need to use some decleration for others to understand the code and that is why xml documentation comes in
    // we use xml documentation with /// 
    //it is like html so we have tags and attributes
    //
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("fname:");
                string? fname = Console.ReadLine();


                Console.Write("lname:");
                string? lname = Console.ReadLine();

                Console.Write("Date:");
                DateTime? HireDate = null;
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    HireDate = date;
                }

                var empId = Generator.GenerateId(fname , lname , HireDate);

                var PassWord = Generator.GeneratePassWord(8);

                Console.WriteLine($"{{ Id : {empId}\n   fname :{fname}\n    lname:{lname}\n    HireDate:{HireDate.ToString()} \n    Password:{PassWord}");
            }
            while (1 == 1);
        }
    }
    /// <summary>
    /// The main Generator Class
    /// </summary>
    /// <remarks>
    ///     This Class Can generate Ids and Passwords
    /// </remarks>
    class Generator
    {
        /// <value> Value of the last Id Sequence</value>
        public static int SequenceId = 1;


        /// <summary>
        ///     Id Generator
        /// </summary>
        /// <remarks>
        ///     This Method Generate a special Id for the Employee based on <paramref name="fname"/> and First Char of <paramref name="lname"/> , in relation with <paramref name="hiredate"/>
        ///     
        /// </remarks>
        /// <list type="bullet">
        ///     <item>
        ///         <term>
        ///             II
        ///         </term>
        ///         <description>
        ///             This is The first Char of the first name and first char of the last name
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>
        ///             II
        ///         </term>
        ///         <description>
        ///             This is The first Char of the first name and first char of the last name
        ///         </description>
        ///     </item>
        /// </list>
        /// <param name="fname">First Name</param>
        /// <param name="lname">Last Name</param>
        /// <param name="hiredate">Hire Date</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        public static string GenerateId(string fname , string lname , DateTime? hiredate)
        {
            if(fname == null)   throw new ArgumentNullException($"{nameof(fname)} can't be null");

            if (lname == null) throw new ArgumentNullException($"{nameof(lname)} can't be null");

            if(hiredate == null) hiredate = DateTime.Now;

            if (hiredate.Value.Date < DateTime.Now.Date) throw new InvalidDataException("Can't be in the past");

            var yy = hiredate.Value.ToString("yy");
            var mm = hiredate.Value.ToString("MM");
            var dd = hiredate.Value.ToString("dd");

            string result = $"{fname[0]}{lname[0]}-{yy}-{mm}-{dd}-{SequenceId++.ToString().PadLeft(2 , '0')}";
            return result;
        }

        public static string GeneratePassWord(int length)
        {
            string allowable = "";
            string result = "";
            for(int i = 31; i < 173; i++)
            {
                allowable += (char)i;
            }
            Random rnd = new Random();
            for(int j = 0; j < length; j++)
            {
                result += allowable[rnd.Next(allowable.Length)];
            }
            return result;
        }
    }
}
