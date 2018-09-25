using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {

        List<Card> hand_ = new List<Card>();
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void AddCardToHand(Card card)
        {
            hand_.Add(card);
        }

       public uint Total()
        {
            uint total = new uint();
            uint suit = new uint();
            foreach (var c in hand_)
            {
                switch (c.Suit)
                {
                    case "Red":
                        suit = 1;
                        break;
                    case "Blue":
                        suit = 2;
                        break;
                    case "Green":
                        suit = 3;
                        break;
                    case "Yellow":
                        suit = 4;
                        break;
                }

                total += suit * c.No;
            }

            return total;
        }

        public void ShowHand()
        {
            Console.WriteLine($"Hand of {Name}:");
            foreach (var c in hand_)
            {
                Console.Write($"{c.Suit} {c.No}, ");
            }
            Console.WriteLine();
        }

    }
}
