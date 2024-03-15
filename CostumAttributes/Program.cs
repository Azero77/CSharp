using System.Reflection;

namespace CostumAttributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> list = new List<Player> { 
                new Player{Name = "Messi" , Pace = 5 , Passing = 10 , Power = 41 , Shooting = 12},
                new Player{Name = "Ronaldo" , Pace = 9 , Passing = 10 , Power = 35 , Shooting = 11},
                new Player{Name = "Messi" , Pace = 7 , Passing = 12 , Power = 41 , Shooting = 12},
            };

            foreach(Player player in list)
            {
                var Properties = player.GetType().GetProperties();
                string PlayerName = (string) typeof(Player).GetProperty("Name").GetValue(player);
                foreach(var prop in Properties)
                {
                  var prop_attribute = prop.GetCustomAttribute<SkillAttribute>();
                  var value = prop.GetValue(player);
                  if(prop_attribute is not null)
                  {
                        if (!prop_attribute.IsValid((int) value))
                        {
                            Console.WriteLine($"{PlayerName} has {value} in {prop.Name} and the range is [{prop_attribute.MinValue} , {prop_attribute.MaxValue}]");
                        }
                  }
                }
            }
        }
    }
}
