using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class City
    {
        public virtual long CityID { get; set; }
        public virtual string CityName { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual Country Country { get; set; }

        public City()
        {
            CityID = 0;
            CityName = "";
            ZipCode = "";
            Country = null;
        }

        public void print()
        {
            Console.WriteLine("       City");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"CityID: {CityID}");
            Console.WriteLine($"CityName: {CityName}");
            Console.WriteLine($"ZipCode: {ZipCode}");
            if (Country != null)
                Console.WriteLine($"Country: {Country.CountryID}");
            else
                Console.WriteLine($"Country: NULL");
            Console.WriteLine("--------------------------");

        }
    }
}
