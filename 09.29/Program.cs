using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._29
{
    internal class Program
    {
        static void Main()
        {
            List<Country> data = File.ReadAllLines("EUcsatlakozas.txt").Select(ln => new Country(ln)).ToList();

            Console.WriteLine($"3. feladat: EU tagállamainak száma: {data.Count()} db");
            Console.WriteLine($"4. feladat: 2007-ben {data.Count(x => x.joinDate.Year == 2007)} ország csatlakozott.");
            Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {data.First(x => x.Name == "Magyarország").joinDate.ToShortDateString()}");
            Console.WriteLine($"6. feladat: Májusban {(data.Any(x => x.joinDate.Month == 5)? "volt" : "nem volt")} csatlakozás!");
            Console.WriteLine($"7. feladat: Legutoljára csatlakozott ország: {data.OrderByDescending(x => x.joinDate).First().Name}");
            Console.WriteLine($"8. feladat: Statisztika \n\t{string.Join("\n\t", data.GroupBy(x => x.joinDate.Year).Select(x => $"{x.Key} - {x.Count()} ország"))}");
        }
    }
}
