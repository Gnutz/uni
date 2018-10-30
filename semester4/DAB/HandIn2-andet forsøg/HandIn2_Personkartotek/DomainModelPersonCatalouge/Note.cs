using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class Note
    {
        public virtual long NoteID { get; set; }
        public virtual string NoteText { get; set; }

        public virtual Person Person { get; set; }

        public Note()
        {
            NoteID = 0;
            NoteText = "";
            Person = new Person();
        }

        public void print()
        {
            Console.WriteLine("       Note");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"NoteID: {NoteID}");
            Console.WriteLine($"NoteText: {NoteText}");
            if (Person != null)
                Console.WriteLine($"PersonID: {Person.PersonId}");
            Console.WriteLine("--------------------------");

        }
    }

}
