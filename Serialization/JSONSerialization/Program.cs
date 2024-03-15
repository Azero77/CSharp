using System.Text.Json;
using System.Xml.Serialization;
using XMLSerialization;


namespace JSONSerialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            //getting the object
            Employee emp = XMLParser(@"C:\Azero\full-csharp\Serialization\XMLSerialization\bin\Debug\net8.0\Test.txt");
            Console.WriteLine(JSONSerializerMethod(emp));
            Console.WriteLine
                (
                JSONDeserializeMethod(JSONSerializerMethod(emp))
                ==
                emp
                );
        }

        internal static string JSONSerializerMethod(Employee emp) 
        {
            string result = "";
            result = JsonSerializer.Serialize(emp);
            return result;
        }

        static Employee JSONDeserializeMethod(string JSONContent) 
        {

            Employee? emp = null;
            emp = JsonSerializer.Deserialize<Employee>(JSONContent);
            return emp;
        }
        static Employee XMLParser(string Path) 
        {
            var file = new FileStream(Path , FileMode.Open , FileAccess.Read);
            Employee? emp = null;
            var xmlSerializer = new XmlSerializer(typeof(Employee));
            using (file) 
            {
                emp = xmlSerializer.Deserialize(file) as Employee;
            }
            return emp;
        }
    }

    public static class EmployeeExtension 
    {
        static string ToJSON(this Employee emp) 
        {
            return Program.JSONSerializerMethod(emp);
        }
    }

}
