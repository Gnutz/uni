using System;
using System.Collections.Generic;
using System.Text;

namespace Personkartotek
{
    public class Adresse
    {
        public uint  AdresseID { get; set; }
        public string Type { get; set; }
        public string Vejnavn { get; set; }
        public uint Vejnummer { get; set; }
        public List<Person> BeboereList { get; set; }
        public By By { get; set; }
 
    }

    public class By : Adresse
    {
        public string ByNavn { get; set; }
        public string PostNr { get; set; }
        public Land Land { get; set; }
    }

    public class Land
    {
        public string Landenavn { get; set; }
        
        string Landkode { get; set; }
    }
}
