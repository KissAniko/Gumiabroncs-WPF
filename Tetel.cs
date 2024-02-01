using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak
{
    class Tetel
    {

        String tipus;  // adott adatok: nyári, téli, négyévszakos
        int szelesseg;
        int magassag;
        string atmero;
        int darab;

        public Tetel(string tipus, int szelesseg, int magassag, string atmero, int darab)
        {
            this.tipus = tipus;
            this.szelesseg = szelesseg;
            this.magassag = magassag;
            this.atmero = atmero;
            this.darab = darab;
        }

        public string Tipus { get => tipus; set => tipus = value; }
        public int Szelesseg { get => szelesseg; set => szelesseg = value; }
        public int Magassag { get => magassag; set => magassag = value; }
        public string Atmero { get => atmero; set => atmero = value; }
        public int Darab { get => darab; set => darab = value; }
    }
}
