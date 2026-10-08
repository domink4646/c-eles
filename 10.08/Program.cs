using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._08
{
    internal class Program
    {
        static void Main()
        {
            List<Kosarlabda> data = File.ReadAllLines("eredmenyek.csv").Skip(1).Select(y => y.Split(';')).Select(x => new Kosarlabda(x[0], x[1], int.Parse(x[2]), int.Parse(x[3]), x[4], DateTime.Parse(x[5]))).ToList();

            Console.WriteLine($"3. feladat:\n\tHazai - {data.Count(x => x.Hazai == "Real Madrid")}\n\tIdegen - {data.Count(x => x.Idegen == "Real Madrid")}");
            Console.WriteLine($"4. feladat: \n\t{(data.Any(x => x.Idegen == x.Hazai) ? "Volt döntetlen!" : "Nem volt döntetlen!")}");
            Console.WriteLine($"5. feladat: Barcelonai csapat neve:\n\t{string.Join("\n\t", data.Where(x => x.Idegen.Contains("Barcelona")).First().Idegen)} ");
            Console.WriteLine($"6. feladat: \n\t{string.Join("\n\t", data.Where(x => x.Idopont.Year == 2004 && x.Idopont.Month == 11 && x.Idopont.Day == 21).Select(x => $"{x.Hazai} - {x.Idegen} ({x.hazaiPont}:{x.idegenPont})"))} ");
            Console.WriteLine($"7. feladat: \n\t{string.Join("\n\t", data.GroupBy(x => x.Helyszin).Where(x => x.Count() > 20).Select(x => $"{x.Key} - {x.Count()}"))}");
            Console.WriteLine($"4. feladat ");

        }
    }
}
