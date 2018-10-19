using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class AlternativeAddress
    {
        public virtual Address Address { get; set; }

        public virtual Person Person { get; set; }
        public virtual string Type { get; set; }

        public AlternativeAddress()
        {
           Address = null;
           Type = "";
        }

        public void print()
        {
            Console.WriteLine("    AlternativeAddress");
            Console.WriteLine("--------------------------");
            Address.print();
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine("--------------------------");

        }
    }
}
