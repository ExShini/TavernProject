using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavernProject.Models
{
    internal class TavernSimulator
    {
        public List<Visitor> Visitors;


        public TavernSimulator() 
        {
            Initialize();
        }

        private void Initialize()
        {
            Visitors = new List<Visitor>()
            {
                new Visitor()
                {
                    Name = "Vulf",
                    Race = VisitorRace.Dwarf,
                },

                new Visitor()
                {
                    Name = "Esabella von Sparrow",
                    Race = VisitorRace.Elf,
                }
            };
        }


    }
}
