using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._15
{
    internal class Program
    {
        public struct Kolcsonzes
        {
            public int Id { get; set; }
            public string Olvaso { get; set; }
            public string Cim { get; set; }
            public string Kategoria { get; set; }
            public int NapiDij { get; set; }
            public int Napok { get; set; }
            public int Osszesen => NapiDij * Napok;
        }

        static void Main()
        {
            Feladat();
        }
        static void Feladat()
        {
            List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>
            {
            new Kolcsonzes { Id = 1, Olvaso = "Nagy Anna",       Cim = "A Gyűrűk Ura",             Kategoria = "Fantasy",     NapiDij = 800,  Napok = 7 },
            new Kolcsonzes { Id = 2, Olvaso = "Kovács Péter",    Cim = "Harry Potter",             Kategoria = "Fantasy",     NapiDij = 700,  Napok = 5 },
            new Kolcsonzes { Id = 3, Olvaso = "Szabó Kft.",      Cim = "C# programozás",           Kategoria = "Informatika", NapiDij = 1500, Napok = 10 },
            new Kolcsonzes { Id = 4, Olvaso = "Tóth Eszter",     Cim = "A történelem könyve",      Kategoria = "Történelem",  NapiDij = 900,  Napok = 3 },
            new Kolcsonzes { Id = 5, Olvaso = "Nagy Anna",       Cim = "Adatbázisok",              Kategoria = "Informatika", NapiDij = 1200, Napok = 8 },
            new Kolcsonzes { Id = 6, Olvaso = "Kiss Béla",       Cim = "A kis herceg",             Kategoria = "Irodalom",    NapiDij = 500,  Napok = 4 },
            new Kolcsonzes { Id = 7, Olvaso = "Varga Zoltán",    Cim = "Magyarország története",   Kategoria = "Történelem",  NapiDij = 1000, Napok = 6 },
            new Kolcsonzes { Id = 8, Olvaso = "Kovács Péter",    Cim = "Python kezdőknek",         Kategoria = "Informatika", NapiDij = 1300, Napok = 9 }
            };

            Console.WriteLine($"\nÁtlagos kölcsönzés értéke:\n\t{kolcsonzesek.Average(x => x.NapiDij)}");
            Console.WriteLine($"\nNév, könyvcím:\n\t{string.Join("\n\t", kolcsonzesek.Select(x => $"{x.Olvaso} - {x.Cim}"))}");
            Console.WriteLine($"\nLegdrágább napidij konyv:\n\t{kolcsonzesek.First(x => x.NapiDij == kolcsonzesek.Max(f => f.NapiDij)).Cim}");
            Console.WriteLine($"\nAhol nagyobb 1000ft:\n\t{string.Join("\n\t", kolcsonzesek.Where(x => x.NapiDij > 1000).Select(x => $"{x.Cim} - {x.NapiDij}"))}");
            Console.WriteLine($"\nHany kolcson, info:\n\t{kolcsonzesek.Count(x => x.Kategoria == "Informatika")}");
            Console.WriteLine($"\nNev, cim, osszesen:\n\t{string.Join("\n\t", kolcsonzesek.OrderByDescending(x => x.Osszesen).Select(x => $"{x.Olvaso} - {x.Cim} - {x.Osszesen}"))}");
            Console.WriteLine($"\nElso:\n\t{kolcsonzesek.First().Cim}");
            Console.WriteLine($"\nNagyobb 10k vane:\n\t{kolcsonzesek.Any(x => x.Osszesen > 10000)}");
            Console.WriteLine($"\nKonyv cim, napidij novekvo:\n\t{string.Join("\n\t", kolcsonzesek.OrderBy(x => x.NapiDij).Select(x => $"{x.Cim} - {x.NapiDij}"))}");
            Console.WriteLine($"\nLegalacsonyabb kolcsonzesi dij:\n\t{kolcsonzesek.Min(x => x.NapiDij)}");
            Console.WriteLine($"\nMinden kolcsonzes legalabb otnapos?:\n\t{kolcsonzesek.Any(x => x.Napok > 5)}");
            Console.WriteLine($"\nAzonosito 5:\n\t{kolcsonzesek.First(x => x.Id.Equals(5)).Cim}");
            Console.WriteLine($"\nOsszes bevetel:\n\t{kolcsonzesek.Sum(x => x.Osszesen)}");
            Console.WriteLine($"\nNev, cim, napidij, abc sorrend, napi dij szerint novekvo:\t\n{string.Join("\n\t", kolcsonzesek.OrderBy(x => x.Olvaso).ThenBy(x => x.NapiDij).Select(x => $"{x.Olvaso} - {x.Cim} - {x.NapiDij}"))}");
            Console.WriteLine($"\nKategoriankenti kolcsonzés:\n\t{string.Join("\n\t", kolcsonzesek.GroupBy(x => x.Kategoria).Select(x => $"{x.Key} - {x.Count()}"))}");
            Console.WriteLine($"\nKategoriankenti bevetel:\n\t{string.Join("\n\t", kolcsonzesek.GroupBy(x => x.Kategoria).OrderBy(x => x.Sum(y => y.Osszesen)).Select(x => $"{x.Key} - {x.Sum(y => y.Osszesen)}"))}");
            Console.WriteLine($"\nElso ketto kihagyva:\n\t{string.Join("\n\t", kolcsonzesek.Skip(2).Select(x => $"{x.Cim}"))}");
            Console.WriteLine($"\nKet legnagyobb erteku kolcsonzes:\n\t{string.Join("\n\t", kolcsonzesek.OrderByDescending(x => x.Osszesen).Take(2).Select(x => $"{x.Olvaso} - {x.Cim}"))}");



        }
    }
}
