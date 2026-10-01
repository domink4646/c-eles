using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._01
{
    internal class Program
    {
        static void Main()
        {
            List<Ellenorzes> data = File.ReadAllLines("jarmu.txt").Select(ln => new Ellenorzes(ln)).ToList();

            Console.WriteLine($"1. feladat: Ellenőrzések száma: {data.Count}");
            Console.WriteLine($"2. feladat: Az ellenőrök munkaórája: {(data.Last().Ora - data.First().Ora) + 1}");
            Console.WriteLine($"3. feladat: {string.Join("\n\t", data.GroupBy(x => x.Ora, y => y.Rendszam).OrderBy(x => x.Key).Select(x => $"{x.Key} - {x.First()}"))}");
            Console.WriteLine($"4. feladat: \n\t{string.Join("\n\t", data.GroupBy(x => x.Kategoria(x.Rendszam)).Select(x => $"{x.Key} - {x.Count()} db"))}");
            var idok = data.Select(x => x.Idotartam()).ToList();
            var kulonbsegek = idok.Skip(1).Select((ido, i) => new
            {
                Kezdo = idok[i],
                Vege = ido,
                Hossz = ido - idok[i]
            }).ToList();
            Console.WriteLine($"5. feladat: {kulonbsegek.OrderByDescending(x => x.Hossz).First()}");


        }
    }
}
