using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._01._2
{
    public enum Sikeres
    {
        I,
        N
    }
    public class Eredmeny
    {
        public DateTime Datum { get; private set; }
        public string Nev { get; private set; }
        public int Helyezes { get; private set; }
        public int befejezett_Korok { get; private set; }
        public int Pont { get; private set; }
        public string Konstruktur { get; private set; }
        public Sikeres siker { get; private set; }
        public int korHatrany { get; private set; }
        public string hiba_Oka { get; private set; }

        public Eredmeny(DateTime datum, string nev, int helyezes, int befejezett_Korok, int pont, string konstruktur, Sikeres siker, int korHatrany, string hiba_Oka)
        {
            Datum = datum;
            Nev = nev;
            Helyezes = helyezes;
            this.befejezett_Korok = befejezett_Korok;
            Pont = pont;
            Konstruktur = konstruktur;
            this.siker = siker;
            this.korHatrany = korHatrany;
            this.hiba_Oka = hiba_Oka;
        }
    }
}
