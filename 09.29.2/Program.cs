using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _09._29._2
{
    internal class Program
    {
        static void Main()
        {
            List<Fuvar> data = File.ReadAllLines("fuvar.csv").Skip(1).Select(ln => ln.Split(';')).Select(x => new Fuvar(int.Parse(x[0]), DateTime.Parse(x[1]), int.Parse(x[2]), double.Parse(x[3]), double.Parse(x[4]), double.Parse(x[5]), (PaymentMethod)Enum.Parse(typeof(PaymentMethod), x[6]))).ToList();

            Console.WriteLine($"3. feladat: {data.Count()} fuvar");
            Console.WriteLine($"4. feladat: {data.Count(x => x.Id == 6185)} fuvar alatt {data.Where(x => x.Id == 6185).Sum(x => x.Income)}$");
            Console.WriteLine($"5. feladat: \n\t{string.Join("\n\t", data.GroupBy(x => x.Method).Select(x => $"{x.Key}: {x.Count()} fuvar"))}");
            Console.WriteLine($"6. feladat: {(data.Sum(x => x.Distance)*1.6):F2}km");
            Console.WriteLine($"7. feladat: {data.OrderByDescending(x => x.Distance).First()}");
            
        }
    }
}
