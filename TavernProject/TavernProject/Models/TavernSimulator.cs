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
        public int AllTableNum { get; private set; }
        public int FreeTableNum { get; private set; }

        public int Day { get; private set; }


        // определяет как много еды на ней умещается
        public int PlateSize { get; private set; }
        public int PlateCost { get; private set; }




        public TavernSimulator() 
        {
            Initialize();
        }

        private void Initialize()
        {
            Gold = GameConsts.StartGold;
            FoodStorage = GameConsts.StartFood;
            AllTableNum = GameConsts.StartTableNum;
            FreeTableNum = AllTableNum;

            PlateSize = GameConsts.StartPlateSize;
            PlateCost = GameConsts.StartPlateCost;

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
            if(visitorToFeed == null) 
                return;

            if(visitorToFeed.IsSiting)
                return;

            if (FreeTableNum <= 0)
                return;

            int foodInPlate = PlateSize;
            foodInPlate = Math.Min(foodInPlate, FoodStorage);
            foodInPlate = Math.Min(foodInPlate, visitorToFeed.Hunger);

            visitorToFeed.Hunger -= foodInPlate;

            if(visitorToFeed.Hunger <= 0)
            {
                Gold += visitorToFeed.Gold;
                visitorToFeed.Gold = 0;
            }
            else
            {
                if(visitorToFeed.Gold < PlateCost)
                {
                    ExpelVisitor(visitorToFeed);
                    return;
                }
                else
                {
                    visitorToFeed.Gold -= PlateCost;
                    Gold += PlateCost;
                }
            }

            FoodStorage -= foodInPlate;
            FreeTableNum--;
        }

    }
}
