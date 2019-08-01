using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Добро Пожаловать в игру Космический бой!");
            Console.WriteLine("------------------------------------------");
            Player player1 = new Player("Игрок 1");
            Player player2 = new Player("Игрок 2");
            Battle battle = new Battle();
            player1.CreateFirstPlayer();
            Console.WriteLine("------------------------------------------");
            player1.Purchases();
            Console.WriteLine("------------------------------------------");
            player1.Status();
            Console.WriteLine("------------------------------------------");
            player2.CreateSecondPlayer();
            Console.WriteLine("------------------------------------------");
            player2.Purchases();
            player2.Status();
            Console.WriteLine("Готовы к битве? Поехали...");
            battle.LoadingBattle();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");
            battle.StartBattle(player1, player2);


        }
    }
}
