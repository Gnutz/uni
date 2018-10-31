using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class AlternativeAddress { 

        public virtual  Person Person { get; set; }
       
        public virtual string Type { get; set; }

        public virtual Address Address { get; set; }

        public AlternativeAddress()
        {
            Type = "";
            Person = new Person();
            Address = new Address();
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
