

using System;
using System.Collections.Generic;

namespace DomainModelPersonCatalogue
{
    public class Person
    {
        public virtual long PersonId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string Surname { get; set; }
        public virtual  Address PrimaryAddress { get; set; }
        public virtual ICollection<AlternativeAddress> AlternativeAddresses { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Phonenumber> PhoneNumbers { get; set; }

        public Person()
        {
            PersonId = 0;
            FirstName = "";
            MiddleName = "";
            Surname = "";
            PrimaryAddress = null;
            AlternativeAddresses = new List<AlternativeAddress>();
            EmailAddresses = new List<EmailAddress>();
            PhoneNumbers = new List<Phonenumber>();
            Notes = new List<Note>();
        }

        public void print()
        {
            Console.WriteLine("         Person");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"PersonID: {PersonId}");
            Console.WriteLine($"FirstName: {FirstName}");
            Console.WriteLine($"MiddleName: {MiddleName}");
            Console.WriteLine($"SurName: {Surname}");

            if(PrimaryAddress != null)
                PrimaryAddress.print();

            Console.WriteLine("Alternative Addresses:");
            foreach (var address in AlternativeAddresses)
            {
                address.print();    
            }

            Console.WriteLine("EmailAddresses:");
            foreach (var email in EmailAddresses)
            {
                email.print();
            }

            Console.WriteLine("Phone numbers:");
            foreach (var number in PhoneNumbers)
            {
                number.print();
            }

            Console.WriteLine("Notes:");
            foreach (var note in Notes)
            {
                note.print();
            }
            Console.WriteLine("--------------------------");

        }
    }

}