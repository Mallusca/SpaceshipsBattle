using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceships
{
    public class Player
    {
        ConsoleKeyInfo changeResultKeyInfo;
        public List<Ship> ShipList = new List<Ship>();
        public static int cost_l = 100;
        public static int cost_m = 200;
        public static int cost_h = 500;
        public int change = 0;
        public int choose = 0;
        public int balance = 1000;
        public string Name;

        public Player(string name)
        {
            Name = name;
        }
        public void Status()
        {
            Console.WriteLine("Игрок {0} имеет {1} кредитов.", Name, balance);
            Console.WriteLine();
            foreach (Ship i in ShipList)
            {
                Console.WriteLine($"{i.Name}");
            }
        }

        public void CreateFirstPlayer()
        {
            Console.WriteLine("Вы первый игрок.");

        }
        public void CreateSecondPlayer()
        {
            Console.WriteLine("Вы второй игрок.");
        }

        public void Purchases()
        {
            Console.WriteLine("Выбирите корабли на 1000 кредитов!");
            Console.WriteLine("Лёгкий  нажмите 1 - цена 100 " + Environment.NewLine +
            "150 здоровье, 50 броня, 100 урон, 3 скорость атаки, 60 уклонение");
            Console.WriteLine("Средний нажмите 2 - цена 200" + Environment.NewLine +
            "300 здоровье, 100 броня, 200 урон, 2 скорость атаки, 40 уклонение");
            Console.WriteLine("Тяжёлый нажмите 3 - цена 500" + Environment.NewLine +
            "600 здоровье, 150 броня, 300 урон, 1 скорость атаки, 20 уклонение");
            do
            {
               
                changeResultKeyInfo = Console.ReadKey();
                Console.WriteLine();
                if (changeResultKeyInfo.Key == ConsoleKey.D1)
                {
                    if (balance >= cost_l)
                    {
                        balance -= cost_l;
                        ShipList.Add(new LightShip());
                        Console.WriteLine("Лёгкий корабль куплен осталось {0} кредитов", balance);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Данный корабль дорогой для вас попробуйте дешевле.");
                    }
                }
                else if (changeResultKeyInfo.Key == ConsoleKey.D2)
                {
                    if (balance >= cost_m)
                    {
                        balance -= cost_m;
                        ShipList.Add(new MiddleShip());
                        Console.WriteLine("Средний корабль куплен осталось {0} кредитов", balance);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Данный корабль дорогой для вас попробуйте дешевле.");
                    }
                }
                else if (changeResultKeyInfo.Key == ConsoleKey.D3)
                {
                    if (balance >= cost_h)
                    {
                        balance -= cost_h;
                        ShipList.Add(new HeavyShip());
                        Console.WriteLine("Тяжёлый корабль куплен осталось {0} кредитов", balance);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Данный корабль дорогой для вас попробуйте дешевле.");
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный символ.");
                }
            }
            while (balance != 0);
            Console.WriteLine("Вы закупились на все кредиты. Удачи!");
        }
        public List<Ship> GetMyShips()
        {
            return ShipList;
        }
        public Ship GetRandomShip()
        {
            List<Ship> aliveShips = new List<Ship>();

            foreach (Ship sp in ShipList)
            {
                if (sp.Health > 0) aliveShips.Add(sp);
            }

            Random rdm = new Random();

            if (aliveShips.Count > 0)
            return aliveShips[rdm.Next(0, aliveShips.Count)];
            else return null;
        }
    }
}
