using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._01
{
    public class Ellenorzes
    {
        public int Ora { get; private set; }
        public int Perc { get; private set; }
        public int mPerc { get; private set; }
        public string Rendszam { get; private set; }

        public Ellenorzes(string sor)
        {
            var adatok = sor.Split(' ');
            Ora = int.Parse(adatok[0]);
            Perc = int.Parse(adatok[1]);
            mPerc = int.Parse(adatok[2]);
            Rendszam = adatok[3];
        }

        public override string ToString()
        {
            return $"{Ora} {Perc} {Rendszam}";
        }

        public string Kategoria(string rendszam)
        {
            switch(rendszam[0])
            {
                case 'B':
                    return "Busz";
                case 'K':
                    return "Kamion";
                case 'M':
                    return "Motor";
                default:
                    return "Személyautó";
            }
        }

        public TimeSpan Idotartam()
        {
            return new TimeSpan(Ora, Perc, mPerc);
        }
    }
}
