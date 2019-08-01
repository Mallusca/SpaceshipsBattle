using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Spaceships
{
    public class Battle
    {        
        public void StartBattle(Player player1, Player player2)
        {
            bool winnerSeted = false;
            bool win1 = false;
            int round = 1;
            int AliveShips;
            while (true)
            {
                Console.WriteLine("Раунд " + round);
                foreach (Ship shp in player1.GetMyShips())
                {
                    Ship shpToDamage = player2.GetRandomShip();
                    if (shpToDamage != null)
                    {
                        if (shpToDamage.Speed == 3)
                            for (int i = 1; i < 3; i++)
                            {
                                ShipsFightFirstPlayerAttack(shp, shpToDamage);
                            }
                        else if (shpToDamage.Speed == 2)
                        {
                            for (int i = 1; i < 2; i++)
                            {
                                ShipsFightFirstPlayerAttack(shp, shpToDamage);
                            }
                        }
                        else if (shpToDamage.Speed == 1)
                        {
                            ShipsFightFirstPlayerAttack(shp, shpToDamage);
                        }
                        else
                        {
                            winnerSeted = true;
                            win1 = true;
                            break;
                        }
                    }                    
                }
                foreach (Ship shp in player2.GetMyShips())
                {
                    Ship shpToDamage = player1.GetRandomShip();
                    if (shpToDamage != null)
                    {
                        if (shpToDamage.Speed == 3)
                            for (int i = 1; i < 3; i++)
                            {
                                ShipsFightSecondPlayerAttack(shp, shpToDamage);
                            }
                        else if (shpToDamage.Speed == 2)
                            for (int i = 1; i < 2; i++)
                            {
                                ShipsFightSecondPlayerAttack(shp, shpToDamage);
                            }
                        else if (shpToDamage.Speed == 1)
                        {
                            ShipsFightSecondPlayerAttack(shp, shpToDamage);
                        }
                    }
                    else
                    {
                        winnerSeted = true;
                        win1 = false;
                        break;
                    }
                }
                round++;
                if (winnerSeted) 
                break;
            }

            if (win1) 
            {
                Console.WriteLine("Победил - Первый игрок");
            }
            else
            {
                Console.WriteLine("Победил - Второй игрок");                      
            }
            Console.ReadLine();
        }
        static int Rdm(int min, int max)
        {
            Random rdm = new Random();
            return rdm.Next(min, max);
        }

        public void LoadingBattle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
        }

        public void ShipsFightFirstPlayerAttack(Ship shpToDamage, Ship shp)
        {
            Console.WriteLine("Игрок 1 наносит " + shp.Damage + " урона, кораблю 2го игрока");

            if (Rdm(0, 100) < shpToDamage.Evasion)
            {
                shpToDamage.GetDamage(shp.Damage - shpToDamage.Armor);
                Console.WriteLine("Но " + shpToDamage.Armor + " заблокировано");
            }
            else
                Console.WriteLine("Шутка. Уклонился");
        }
        public void ShipsFightSecondPlayerAttack(Ship shpToDamage, Ship shp)
        {
            Console.WriteLine("Игрок 2 наносит " + shp.Damage + " урона, кораблю 1го игрока");

            if (Rdm(0, 100) < shpToDamage.Evasion)
            {
                shpToDamage.GetDamage(shp.Damage - shpToDamage.Armor);
                Console.WriteLine("Но " + shpToDamage.Armor + " заблокировано");
            }
            else
                Console.WriteLine("Шутка. Уклонился");
        }
    }
}
        