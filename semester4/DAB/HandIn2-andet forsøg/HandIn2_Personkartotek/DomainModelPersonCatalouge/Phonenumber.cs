using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class Phonenumber
    {
        public long PhoneNumberID { get; set; }
        public string PhoneNumber { get; set; }
        public string type { get; set; }
        public PhoneCompany PhoneCompany { get; set; }
        public Person Person { get; set; }

        public Phonenumber()
        {
           PhoneNumberID = 0;
           PhoneNumber = "";
           type = "";
           PhoneCompany = new PhoneCompany();
        }

        public void print()
        {
            Console.WriteLine("       Phonenumber");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"Person: {Person.PersonId}");
            Console.WriteLine($"PhoneCompany: {PhoneCompany.PhoneCompanyID}");
            Console.WriteLine("--------------------------");

        }
    }
}
