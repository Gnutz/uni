using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class EmailAddress
    {
        public virtual long EmailAddressID { get; set; }
        public virtual string Email { get; set; }

        public virtual Person Person { get; set; }

 
        public EmailAddress()
        {
            EmailAddressID = 0;
            Email = "";
            Person = new Person();
        }

        public void print()
        {
            Console.WriteLine("       EmailAddress");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"EmailAddressID: {EmailAddressID}");
            Console.WriteLine($"Email: {Email}");
            if(Person != null)
                Console.WriteLine($"PersonID: {Person.PersonId}");
            Console.WriteLine("--------------------------");

        }
    }
}

