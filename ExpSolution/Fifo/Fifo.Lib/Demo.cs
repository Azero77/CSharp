namespace Fifo.Lib
{
    public class Demo
    {
        public string Name { get; set; }

        public string Description()
        {
            return this.Name + "------";
        }

        public Demo(string name)
        {
            Name = name;
        }
    }
}
