using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelPersonCatalogue
{
    public class Note
    {
        public virtual long NoteID { get; set; }
        public virtual string NoteText { get; set; }

        public Note()
        {
            NoteID = 0;
            NoteText = "";
        }

        public void print()
        {
            Console.WriteLine("       Note");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"NoteID: {NoteID}");
            Console.WriteLine($"NoteText: {NoteText}");
            Console.WriteLine("--------------------------");

        }
    }

}
