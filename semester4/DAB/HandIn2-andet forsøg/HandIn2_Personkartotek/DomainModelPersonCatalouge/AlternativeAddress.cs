using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class AlternativeAddress : Address
    {

        public virtual  Person Person { get; set; }
       
        public virtual string Type { get; set; }

        public AlternativeAddress() : base()
        {
            Type = "";
            Person = new Person();
        }

        public void print()
        {
            Console.WriteLine("    AlternativeAddress");
            Console.WriteLine("--------------------------");
            base.print();
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine("--------------------------");

        }
    }
}
