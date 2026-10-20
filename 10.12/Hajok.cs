using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._12
{
    public class Hajok
    {
        public int helyezes { get; private set; }
        public string kategoria { get; private set; }
        public string hajo { get; private set; }
        public string klub { get; private set; }
        public string kormanyos { get; private set; }
        public int nap { get; private set; }
        public int ora { get; private set; }
        public int perc { get; private set; }

        public int osszperc => (nap * 24 * 60) + (ora * 60) + perc;

        public Hajok(string sor)
        {
            var adatok = sor.Split(';');
            helyezes = int.Parse(adatok[0]);
            kategoria = adatok[1];
            hajo = adatok[2];
            klub = adatok[3];
            kormanyos = adatok[4];
            nap = int.Parse(adatok[5]);
            ora = int.Parse(adatok[6]);
            perc = int.Parse(adatok[7]);
        }
    }
}
