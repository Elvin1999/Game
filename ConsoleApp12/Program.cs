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
        public int GetRandomArmyMember()
        {
            Random random = new Random();
            var membernumber = random.Next(0, myarmy.Count);
            return membernumber;
        }
        public void AttackToOpponent()
        {
            int index = GetRandomArmyMember();
            opponentarmy.RemoveAt(index);
            Console.Clear();
            ShowGame();
        }
        public void AttackFromOpponent()
        {
            int index = GetRandomArmyMember();
            index = GetRandomArmyMember();
            myarmy.RemoveAt(index);
        }
        public void ShowGame()
        {
            Console.WriteLine("        ===My army===           ");
            ShowArmy(myarmy);
            Console.WriteLine("      ===Opponent army===       ");
            ShowArmy(opponentarmy);
        }
        public void Run()
        {
            //my army
            SoldierFactory soldier = new SoldierFactory();
            TankFactory tank = new TankFactory();
            HelicopterFactory helicopter = new HelicopterFactory();
            var mysoldier = GetUnit(soldier);
            var mytank = GetUnit(tank);
            var myhecilopter = GetUnit(helicopter);
            //opponent army
            SoldierFactory osoldier = new SoldierFactory();
            TankFactory otank = new TankFactory();
            HelicopterFactory ohelicopter = new HelicopterFactory();
            var opsoldier = GetUnit(osoldier);
            var optank = GetUnit(otank);
            var ophecilopter = GetUnit(ohelicopter);
            var mode = GetGameMode();
            if (mode == 1)
            {
                myarmy.Add(mysoldier);
                myarmy.Add(mytank);
                myarmy.Add(myhecilopter);
                opponentarmy.Add(opsoldier);
                opponentarmy.Add(ophecilopter);
                opponentarmy.Add(optank);
            }
            else if (mode == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    myarmy.Add(mysoldier);
                    myarmy.Add(mytank);
                    myarmy.Add(myhecilopter);
                    opponentarmy.Add(opsoldier);
                    opponentarmy.Add(ophecilopter);
                    opponentarmy.Add(optank);
                }
            }
            ShowGame();
            Console.WriteLine("To attack select [1]");
            int select = Convert.ToInt32(Console.ReadLine());

            if (select == 1)
            {
                AttackToOpponent();
                System.Threading.Thread.Sleep(1000);
                AttackFromOpponent();
            }
            Console.Clear();
            ShowGame();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opponent attacked to you");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GO TO THE NEXT LEVEL select [2]");
            select = Convert.ToInt32(Console.ReadLine());
            if (select == 2)
            {
                opponentarmy.Clear();
                myarmy.Clear();
                if (mode == 1)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        myarmy.Add(mysoldier);
                        myarmy.Add(mytank);
                        myarmy.Add(myhecilopter);
                        opponentarmy.Add(opsoldier);
                        opponentarmy.Add(ophecilopter);
                        opponentarmy.Add(optank);
                    }
                }
                else if (mode == 2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        myarmy.Add(mysoldier);
                        myarmy.Add(mytank);
                        myarmy.Add(myhecilopter);
                        opponentarmy.Add(opsoldier);
                        opponentarmy.Add(ophecilopter);
                        opponentarmy.Add(optank);
                    }
                }
                Console.Clear();
                ShowGame();
                Console.WriteLine("To attack select [1]");
                select = Convert.ToInt32(Console.ReadLine());

                if (select == 1)
                {
                    AttackToOpponent();
                    System.Threading.Thread.Sleep(1000);
                    AttackFromOpponent();
                }
                Console.Clear();
                ShowGame();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opponent attacked to you");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var game = new Game();
            game.Run();
        }
    }
}
