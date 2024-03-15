using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using XMLSerialization;
namespace BinaryFormaterCA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //getting the employee in XMl Form
            var xmlContent = File.ReadAllText(@"C:\Azero\full-csharp\Serialization\XMLSerialization\bin\Debug\net8.0\Test.txt");
            var E1 = Deserialize(xmlContent);
            //convert it to binary(serialization)
            using (var stream = new FileStream(@"C:\Azero\full-csharp\Serialization\BinaryFormaterCA\bin\Debug\net8.0\Test.txt" , FileMode.OpenOrCreate , FileAccess.ReadWrite))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, E1);
            }
        }
        static Employee Deserialize(string XmlContent)
        {
            Employee emp;
            var xmlSerializer = new XmlSerializer(typeof(Employee));
            TextReader reader = new StringReader(XmlContent);
            emp = xmlSerializer.Deserialize(reader) as Employee;
            return emp;
        }
    }
}
