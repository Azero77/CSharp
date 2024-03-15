using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XMLSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(1, "Anas", "Zaggar", new List<string> { "Working1", "Working2" });
            var xmlE1 = ser(e1);
            Console.WriteLine(xmlE1);
            Console.Read();
        }

        public static  string ser(Employee e1)
        {
            string result = "";
            var xmlSerializer = new XmlSerializer(e1.GetType());
            using (var f = new FileStream("Test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (var writer = XmlWriter.Create(f,new XmlWriterSettings { Indent = true }))
                {
                    xmlSerializer.Serialize(writer, e1);

                    byte[] data = new byte[f.Length];
                    int BytesToRead = (int) f.Length;
                    int BytesRead = 0;
                    f.Seek(0, SeekOrigin.Begin);
                    while (BytesToRead > 0)
                    {
                        int n = f.Read(data ,BytesRead , BytesToRead);
                        BytesToRead -= n;
                        BytesRead += n;
                    }

                    for (int i = 0, l = data.Length; i < l; i++)
                    {
                        result += (char)data[i];
                    }
                }

            }
            return result;
        }
    }


    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public List<string> Benefits { get; set; }
        public Employee() { }
        public Employee(int id, string fName, string lName, List<string> benefits)
        {
            Id = id;
            FName = fName;
            LName = lName;
            Benefits = benefits;
        }

        public override bool Equals(object? obj)
        {
            /* var Emp2 = obj as Employee;
             if (Emp2 is null) return false;*/

            if (ReferenceEquals(this, null)) return ReferenceEquals(obj, null);
            if (obj is null) return false;
            var emp2 = obj as Employee;
            if (emp2 is null) return false;

            return this.Id == emp2.Id;
        }

        public static bool operator ==(Employee a, Employee b) { return a.Equals(b); }
        public static bool operator !=(Employee a, Employee b) { return !a.Equals(b); }
    }
}
