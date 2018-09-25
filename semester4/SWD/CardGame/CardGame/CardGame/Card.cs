using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        public Card(string suit, uint no)
        {
            Suit = suit;
            No = no;
        }
        public string Suit { get; set; }
        public uint No { get; set; }


    }
}
