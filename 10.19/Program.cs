using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._19
{
    internal class Program
    {
        static void Main()
        {
            List<Weekend> data = File.ReadAllLines("nyitohetvege.txt").Skip(1).Select(ln => new Weekend(ln)).ToList();
            Console.WriteLine($"3. feladat: Filmek száma: {data.Count} db");
            Console.WriteLine($"4. feladat: UIP Duna Film forgalmazó 1. hetes bevételeinek összege: {data.Where(x => x.forgalmazo == "UIP").Sum(x => x.bevetel)} ");
            Console.WriteLine($"5. feladat: {string.Join("\n\t", data.Where(x => x.latogatokSzama == data.Max(f => f.latogatokSzama)))}");
            Console.WriteLine($"6. feladat: {(data.Any(x => x.eredetiCim.Split(' ').All(y => y.ToLower().StartsWith("w") && x.magyarCim.Split(' ').All(f => f.ToLower().StartsWith("w")))) ? "Van ilyen!" : "Nincs ilyen!")}");
            File.WriteAllText("stat.csv", "Forgalmazó;Film darabszám\n");
            File.AppendAllText("stat.csv", string.Join("\n", data.GroupBy(x => x.forgalmazo).Where(x => x.Count() > 1).Select(x => $"{x.Key};{x.Count()}")));
            Console.WriteLine($"8. feladat: A leghosszabb időszak két InterCom-os bemutató között: {data.Where(x => x.forgalmazo.ToLower() == "intercom").Select(x => x.bemutato).Distinct().OrderBy(x => x).Zip(data.Where(x => x.forgalmazo.ToLower() == "intercom").Select(x => x.bemutato).Distinct().OrderBy(x => x).Skip(1), (a,b) => (b-a).Days).Max()}");
        }
    }
}
