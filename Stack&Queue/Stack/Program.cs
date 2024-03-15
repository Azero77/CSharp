using System;
using System.Collections.Generic;
namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Command> undo = new Stack<Command>();
            Stack<Command> redo = new Stack<Command>();
            string _line;
            while (true)
            {
                Console.Write("URL('exit to stop'):");
                _line = Console.ReadLine().ToLower();
                if(_line == "exit") break;
                else if(_line == "back")
                {
                    if (undo.Count > 0)
                    {
                        var item = undo.Pop();
                        redo.Push(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if(_line == "forward")
                {
                    if(redo.Count > 0)
                    {
                        var item = redo.Pop();
                        undo.Push(item);
                    }
                    else
                    {

                        continue;
                    }
                }
                else
                {
                    undo.Push(new Command(_line));
                }

                Console.Clear();

                Print("back", undo);
                Print("forward", redo);
            }
            
        }

        public static void Print(string name , Stack<Command> commands)
        {
            Console.WriteLine(name + "History:");
            Console.BackgroundColor = name == "back" ? ConsoleColor.DarkGreen : ConsoleColor.DarkBlue;
            foreach (var command in commands)
            {
                Console.WriteLine("\t"+ command);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }

    class Command
    {
        public Command(string url)
        {
            _url = url;
            _date = DateTime.Now;
        }

        public string _url { get; set; }
        public DateTime _date { get; set;}
        public override string ToString()
        {
            return $"{{{_url}}}";
        }
    }
}
