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

        public int Gold { get; private set; }
        public int FoodStorage { get; private set; }

        public TavernSimulator() 
        {
            Initialize();
        }

        private void Initialize()
        {
            Gold = GameConsts.StartGold;
            FoodStorage = GameConsts.StartFood;

            Visitors = new List<Visitor>()
            {
                new Visitor()
                {
                    Name = "Vulf",
                    Race = VisitorRace.Dwarf,
                    Gold = 55,
                    Hunger = 60,
                    Age = 21,
                },

                new Visitor()
                {
                    Name = "Esabella von Sparrow",
                    Race = VisitorRace.Elf,

                    Gold = 11,
                    Hunger = 20,
                    Age = 450,
                },

                new Visitor()
                {
                    Name = "Boris Govrilov",
                    Race = VisitorRace.Human,

                    Gold = 89,
                    Hunger = 16,
                    Age = 46,
                },


                new Visitor()
                {
                    Name = "Vark Zubakov",
                    Race = VisitorRace.Orc,

                    Gold = 1,
                    Hunger = 3,
                    Age = 15,
                },
            };
        }



        // выгоняем посетителей из таверны
        public void ExpelVisitor(Visitor visitorToExpel)
        {
            if (visitorToExpel == null)
                return;

            Visitors.Remove(visitorToExpel);
        }

        // кормим посетителя
        public void FeedVisitor(Visitor visitorToFeed)
        {

        }

    }
}
