using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._08._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tenisz> data = File.ReadAllLines("noitenisz.csv").Skip(1).Select(x => new Tenisz(x)).ToList();

            Console.WriteLine($"3. feladat: \n\t{(data.Any(x => x.gyoztesNeve == "Tara Moore") ? "Igen" : "Nem")}");
            Console.WriteLine($"4. feladat: \n\t{(data.All(x => x.gyoztesNeve == "Simona Halep" && x.gyoztesMagassaga > x.vesztesMagassaga) ? "Igen" : "Nem")}");
            Console.WriteLine($"5. feladat: \n\t{data.Count(x => x.Torna == "Charleston" && (x.vesztesNemzetisege == "AUS" || x.gyoztesNemzetisege == "AUS") && (x.gyoztesNemzetisege != "AUS" && x.vesztesNemzetisege == "AUS"))}");
            Console.WriteLine($"6. feladat: \n\t{(((double)data.Count(x => x.Burkolat == "Fű") / ((double)data.Count(x => x.Burkolat != ""))) * 100):F2}%");
            var youngest = data.OrderBy(x => x.gyoztesEletkora).First();
            Console.WriteLine($"7. feladat: \n\t{youngest.gyoztesNeve} - {Math.Floor(youngest.gyoztesEletkora)}");
            Console.WriteLine($"8. feladat: \n\t{string.Join("\n\t", data.Where(x => x.Datum.Month == 9 && x.Datum.Day == 22).Select(x => $"{x.gyoztesNeve} - {x.vesztesNeve}: {x.Eredmeny}"))}");
            var szept_22 = string.Join("\n\t", data.Where(x => x.Datum.Month == 9 && x.Datum.Day == 22).Select(x => $"{x.gyoztesNeve} - {x.vesztesNeve}: {x.Eredmeny}"));
            File.WriteAllText("szeptember22.txt", szept_22);
        }
    }
}
