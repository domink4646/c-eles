using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._28
{
    internal class Snooker
    {
        public int Helyezes { get; private set; }
        public string Nev { get; private set; }
        public string Orszag { get; private set; }
        public int Nyeremeny { get; private set; }

        public Snooker(string ln)
        {
            string[] adatok = ln.Split(';');
            Helyezes = int.Parse(adatok[0]);
            Nev = adatok[1];
            Orszag = adatok[2];
            Nyeremeny = int.Parse(adatok[3]);
        }

        public Snooker(int helyezes, string nev, string orszag, int nyeremeny)
        {
            Helyezes = helyezes;
            Nev = nev;
            Orszag = orszag;
            Nyeremeny = nyeremeny;
        }
    }

}
