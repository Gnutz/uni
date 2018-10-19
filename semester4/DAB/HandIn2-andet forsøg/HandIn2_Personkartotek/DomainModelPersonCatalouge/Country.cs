using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class Country
    {
        public virtual long CountryID { get; set; }
        public virtual string CountryName { get; set; }
        public virtual string CountryCode { get; set; }

        public Country()
        {
           CountryID = 0;
           CountryName = "";
           CountryCode = "";
        }

        public void print()
        {
            Console.WriteLine("       Country");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"CountryID: {CountryID}");
            Console.WriteLine($"CountryName: {CountryName}");
            Console.WriteLine($"CountryCode: {CountryCode}");
            Console.WriteLine("--------------------------");

        }
    }
}
