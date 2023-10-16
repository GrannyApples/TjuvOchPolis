using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class Person
    {
        public string Polis { get; set; }
        public string Tjuv { get; set; }
        public string Medborgare { get; set; }

        public Person(string polis,string tjuv,string medborgare)

        {
            Medborgare = medborgare;
            Polis = polis;  
            Tjuv = tjuv;
            
        }
    }
}
