using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class PhoneCompany
    {
        public long PhoneCompanyID { get; set; }
        public string CompanyName { get; set; }

        public PhoneCompany()
        {
            PhoneCompanyID = 0;
            CompanyName = "";

        }

        public void print()
        {
            Console.WriteLine("       PhoneCompany");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"PhoneCompanyID: {PhoneCompanyID}");
            Console.WriteLine($"CompanyName: {CompanyName}");
            Console.WriteLine("--------------------------");

        }
    }

}
