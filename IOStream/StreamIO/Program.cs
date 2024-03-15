using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace StreamIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Example7();
        }
        public static void Example1()
        {
            string Path = @"C:\2ND_Year\errors.txt";

            using (FileStream File = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite)) 
            {
                Console.WriteLine("Can Read:" + File.CanRead);
                Console.WriteLine("Can Write:" + File.CanWrite);
                Console.WriteLine("Can Seek:" + File.CanSeek);
                Console.WriteLine("Can CanTimeout:" + File.CanTimeout);
                Console.WriteLine("Position:" + File.Position);
                for (byte i = 65; i < 129; i++) 
                {
                    File.WriteByte(i);
                    if (i == 75) File.WriteByte(10);
                }
                Console.WriteLine("Position:" + File.Position);
            }

        }
        public static void Example2() 
        {
            using (var File = new FileStream("C:\\Users\\mazag\\OneDrive\\Desktop\\test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] data = new byte[File.Length];
                int BytesToRead =(int) File.Length;
                int BytesRead = 0;
                while (BytesToRead > 0) 
                {
                    int n = File.Read(data, BytesRead, BytesToRead);
                    BytesRead += n;
                    BytesToRead -= n;
                }

                foreach (var b in data) 
                {
                    Console.Write((char) b);
                }
            }
        }

        static void Example3()
        {
            using (var File = new FileStream(@"C:\Users\mazag\OneDrive\Desktop\test3.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite))
            {
                File.Seek(20,SeekOrigin.Begin);

                File.WriteByte(65);
                for (int i = 0; i < File.Length; i++)
                {
                    Console.WriteLine(File.ReadByte());
                }

                Console.WriteLine(File.Position);
            }
        }

        static void Example4() 
        {
            var sr = new StreamReader(new FileStream("C:\\Users\\mazag\\OneDrive\\Desktop\\test.txt" , FileMode.Open , FileAccess.Read));
            string Line;
            while((Line = sr.ReadLine())is not null)
            {
                Console.WriteLine(Line);
            };
        }

        static void Example5()
        {
            var sr = new StreamWriter("C:\\Users\\mazag\\OneDrive\\Desktop\\test5.txt");
            sr.WriteLine("This");
            sr.WriteLine("is");
            sr.WriteLine("C#");
        }
        static void Example6 ()
        {
            var e = File.ReadAllBytes("C:\\Users\\mazag\\OneDrive\\Desktop\\test.txt");
            foreach (var a in e) Console.WriteLine((char) a);
        }

        static void Example7()
        {
            File.WriteAllText("C:\\Users\\mazag\\OneDrive\\Desktop\\test5.txt", "This is C#");
        }  
    }
}
