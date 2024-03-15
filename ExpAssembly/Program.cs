using System.Reflection;

namespace ExpAssembly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(Program);
            var assembly = type.Assembly;
            var stream = assembly.GetManifestResourceStream(type, "data.Countries.json");
            var data = new BinaryReader(stream).ReadBytes((int) stream.Length);

            for(int i = 0; i < data.Length; i++)
            {
                Console.Write((char)data[i]);
                Thread.Sleep(200);
            }
        }
    }
}
