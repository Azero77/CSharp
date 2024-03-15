using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumAttributes
{
    internal class Player
    {
        public string Name { get; set; }

        [Skill(nameof(Power) , 1 , 40)]
        public int Power { get; set; } //1 -40

        [Skill(nameof(Pace), 1, 10)]
        public int Pace {  get; set; } // 1 - 10

        [Skill(nameof(Shooting), 1, 20)]
        public int Shooting { get; set; } //1 - 20

        [Skill(nameof(Passing), 1, 10)]
        public int Passing { get; set; } // 1-10
    }
}
