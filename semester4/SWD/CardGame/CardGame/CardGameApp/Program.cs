using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;

namespace CardGameApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Player pl1 = new Player("Player1");
            pl1.AddCardToHand(new Card("Green", 7));
            pl1.ShowHand();
            Console.Write($"Player total: {pl1.Total()}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
