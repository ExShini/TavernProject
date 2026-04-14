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
        public string Name;
        public VisitorRace Race;

    }
}
