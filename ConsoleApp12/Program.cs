using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    interface IUnit
    {
        void Attact();
        void ShowUnit();
    }
    class Tank : IUnit
    {
        public Tank(int point)
        {
            Point = point;
        }

        public int Point { get; set; }
        public void Attact()
        {
            Console.WriteLine("I hit as Tank (800 points decreased)");
        }

        public void ShowUnit()
        {
            Console.Write($"===TANK===       point=>{Point}");
        }
    }
    class Helicopter : IUnit
    {
        public Helicopter(int point)
        {
            Point = point;
        }

        public int Point { get; set; }
        public void Attact()
        {
            Console.WriteLine("I hit as Helicopter (500 points decreased)");
        }

        public void ShowUnit()
        {
            Console.Write($"===HELICOPTER=== point=>{Point}");
        }
    }
    class Soldier : IUnit
    {
        public Soldier(int point)
        {
            Point = point;
        }
        public int Point { get; set; }
        public void Attact()
        {
            Console.WriteLine("I hit as Soldier (100 points decreased)");
        }

        public void ShowUnit()
        {
            Console.Write($"===SOLDIER===    point=>{Point}");
        }
    }
    interface IUnitFactory
    {
        IUnit CreateUnit();
    }
    class TankFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new Tank(500);
        }
    }
    class HelicopterFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new Helicopter(800);
        }
    }
    class SoldierFactory : IUnitFactory
    {
        public IUnit CreateUnit()
        {
            return new Soldier(100);
        }
    }

    class Game
    {
        List<IUnit> myarmy = new List<IUnit>();
        List<IUnit> opponentarmy = new List<IUnit>();
        public IUnit GetUnit(IUnitFactory factory)
        {
            IUnit unit = factory.CreateUnit();
            return unit;
        }
        public void ShowArmy(List<IUnit> army)
        {
            foreach (var item in army)
            {
                item.ShowUnit();
                Console.WriteLine();

            }
        }
        public int GetGameMode()
        {
            Console.WriteLine("=====GAME=====");
            Console.WriteLine("NORMAL mode [1]");
            Console.WriteLine("HARD mode [2]");
            Console.WriteLine("==============");
            Console.WriteLine("Select - >");
            int selection = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return selection;
        }
        public void Run()
        {
            SoldierFactory soldier = new SoldierFactory();
            TankFactory tank = new TankFactory();
            HelicopterFactory helicopter = new HelicopterFactory();
            var mysoldier = GetUnit(soldier);
            var mytank = GetUnit(tank);
            var myhecilopter = GetUnit(helicopter);
            SoldierFactory osoldier = new SoldierFactory();
            TankFactory otank = new TankFactory();
            HelicopterFactory ohelicopter = new HelicopterFactory();
            var opsoldier = GetUnit(osoldier);
            var optank = GetUnit(otank);
            var ophecilopter = GetUnit(ohelicopter);
            var mode = GetGameMode();
            if (mode == 1)
            {
                myarmy.Add(mysoldier); myarmy.Add(mytank); myarmy.Add(myhecilopter);
                opponentarmy.Add(opsoldier); opponentarmy.Add(ophecilopter); opponentarmy.Add(optank);
            }
            else if (mode == 2)
            {
                myarmy.Add(mysoldier);
                myarmy.Add(mysoldier);
                myarmy.Add(mytank);
                myarmy.Add(mytank);
                myarmy.Add(myhecilopter);
                myarmy.Add(myhecilopter);
                opponentarmy.Add(opsoldier); opponentarmy.Add(opsoldier);
                opponentarmy.Add(ophecilopter); opponentarmy.Add(ophecilopter);
                opponentarmy.Add(optank); opponentarmy.Add(optank);
            }
            Console.WriteLine("        ===My army===           ");
            ShowArmy(myarmy);
            Console.WriteLine("      ===Opponent army===       ");
            ShowArmy(opponentarmy);
            //mysoldier.Attact();
            //mytank.Attact();
            //myhecilopter.Attact();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int x = 0; int y = 0;
            //while (true)
            //{
            //    Console.Clear();

            //    Console.SetCursorPosition(x, y);
            //    Console.WriteLine("*");
            //    System.Threading.Thread.Sleep(1000);
            //    ++x;

            //}

            var game = new Game();
            game.Run();
        }
    }
}
