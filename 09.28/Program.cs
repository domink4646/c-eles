using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Snooker> data = File.ReadAllLines("snooker.txt").Skip(1).Select(x => new Snooker(x)).ToList();

            Console.WriteLine($"3. feladat: {data.Count} versenyző indult.");
            Console.WriteLine($"4. feladat: {data.Average(x => x.Nyeremeny).ToString("F2")}");
            Console.WriteLine($"5. feladat: Legjobban kereső kínai játékos\n{string.Join("\n", data.Where(x => x.Orszag == "Kína" && x.Nyeremeny == data.Where(f => f.Orszag == "Kína").Max(f => f.Nyeremeny)).Select(x => $"Helyezés: {x.Helyezes}\nNév: {x.Nev}\nOrszág: {x.Orszag}\nNyeremény összege: {x.Nyeremeny * 380}"))}");
            Console.WriteLine($"6. feladat: Van norvég versenyző? {(data.Any(x => x.Orszag == "Norvégia") ? "Van" : "Nincs")}");
            Console.WriteLine($"7. feladat: \t\n{string.Join("\t\n", data.GroupBy(x => x.Orszag).Where(x => x.Count() > 4).Select(x => $"{x.Key} - {x.Count()}"))}");

        }
    }
}
