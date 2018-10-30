using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class Address
    {
        public virtual long AddressID { get; set; }
        public virtual string Street { get; set; }
        public virtual string HouseNumber { get; set; }
        public virtual City City { get; set; }

        public Address()
        {
           AddressID = 0;
           Street = "";
           HouseNumber = "";
           City = new City();
        }

        public void print()
        {
            Console.WriteLine("     Address");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"AddressID: {AddressID}");
            Console.WriteLine($"Street: {Street}");
            Console.WriteLine($"House number: {HouseNumber}");
            Console.WriteLine($"City: {City.CityID}");
            Console.WriteLine("--------------------------");

        }
    }
}
