using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Personkartotek
{
    public class Person
        {
            public uint PersonID { get; set;}          // pk = Primary Key

            public string Fornavn { get; set;}
           public string Efternavn { get; set;}

            public List<string> Email { get; set;}

            public Adresse PrimærAdresse { get; set;}

            public List<TelefonNr> Telefonnumre { get; set;}

            public List<string> Noter { get; set;}

        }
    
