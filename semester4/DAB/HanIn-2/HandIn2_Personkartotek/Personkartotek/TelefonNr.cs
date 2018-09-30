using System;
using System.Collections.Generic;
using System.Text;

namespace Personkartotek
{

    public class TelefonNr : Person
    {
        public string Nummer { get; set; }
        public Person Ejer { get; set; }             // fk = Foreign key
        public string Type { get; set; }
        Teleselskab Selskab { get; set; };
    }


    public class Teleselskab : TelefonNr
    {
       public string Selskabsnavn { get; set; }
        
    }
}
