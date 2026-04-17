using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavernProject.Models
{

    public enum VisitorRace
    {
        Human,
        Elf,
        Dwarf,
        Orc
    }


    public class Visitor
    {
        public string Name { get; set; }
        public string RaceName { get { return Race.ToString(); } }
        
        public VisitorRace Race;

        public int Hunger { get; set; }
        public int Gold { get; set; }
        public int Age { get; set; }

    }
}
