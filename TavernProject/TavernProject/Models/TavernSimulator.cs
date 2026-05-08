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


        // произвдительность таверны
        public int FoodGrow { get; private set; }


        private VisitorGenerator _visGen;


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

            FoodGrow = GameConsts.StartFoodGrow;

            _visGen = new VisitorGenerator();
            Visitors = new List<Visitor>();

            for (int i = 0; i < GameConsts.StartVisitorNum; i++)
            {
                Visitors.Add(_visGen.CreateVisitor());
            }
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
                ExpelVisitor(visitorToFeed);
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

            if(FreeTableNum <= 0)
            {
                RunNextDay();
            }
        }


        public void RunNextDay()
        {
            Day++;
            Random rnd = new Random();

            for (int i = 0; i < Visitors.Count; i++)
            {
                var visitor = Visitors[i];
                visitor.IsSiting = false;

                visitor.Hunger += rnd.Next(GameConsts.HangerGrowMin, GameConsts.HangerGrowMax);

                var maxHunger = visitor.MaxHunger;
                if(maxHunger <= visitor.Hunger)
                {
                    ExpelVisitor(visitor);
                }
            }

            FoodStorage += FoodGrow;

            Visitors.Add(_visGen.CreateVisitor());
        }

    }
}
