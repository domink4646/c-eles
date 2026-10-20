using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._12
{
    internal class Program
    {
        static void Main()
        {
            List<Hajok> data = File.ReadAllLines("kekszalag.csv").Skip(1).Select(ln => new Hajok(ln)).ToList();

            Console.WriteLine($"2. feladat: {data.Count} hajó indult a versenyen.");
            Console.WriteLine($"3. feladat: Első tíz hajó neve, klubja, hány perc alatt teljesítették a távot: \n\t{string.Join("\n\t", data.Select(x => $"{x.hajo} - {x.klub} {(x.nap * 24 * 60) + (x.ora * 60) + x.perc} perc").Take(10))}");
            var kategoriak = data.GroupBy(x => x.kategoria).Count();
            Console.WriteLine($"4. feladat: Kategoriák nevei egyszer kiírva: \n\t{string.Join("\n\t", data.GroupBy(x => x.kategoria).Select(x => $"{x.Key}"))}\n\n\tÖsszesen {kategoriak} db kategória szerepel az adatok között!");
            Console.WriteLine($"5. feladat: \n\t{string.Join("\n\t", data.Take(3).OrderBy(x => x.osszperc).Select(x => $"{((160 / (x.osszperc / 60))):F2}km/h"))}");


        }
    }
}
