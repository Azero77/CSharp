using System.Xml.Serialization;
using XMLSerialization;

namespace XMLDeserializationCA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var XmlContent = File.ReadAllText(@"C:\Azero\full-csharp\Serialization\XMLSerialization\bin\Debug\net8.0\Test.txt");

            Employee? E1 = Deserialize(XmlContent);
            Console.WriteLine(E1);
            Console.ReadKey();
        }

        static Employee Deserialize(string XmlContent) 
        {
            Employee emp;
            var XmlSerializer = new XmlSerializer(typeof(Employee));
            TextReader reader = new StringReader(XmlContent);
            emp = XmlSerializer.Deserialize(reader) as Employee;
            return emp;
        }
    }
}
