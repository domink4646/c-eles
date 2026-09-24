using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._24._2
{
    public class Kosarasok
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Nationality { get; private set; }
        public string birthPlace { get; private set; }
        public DateTime birthDate { get; private set; }

        public Kosarasok(string ln)
        {
            string[] adatok = ln.Split(';');
            Id = Convert.ToInt32(adatok[0]);
            Name = adatok[1];
            Nationality = adatok[2];
            try
            {
                birthPlace = adatok[3];
            }
            catch (Exception)
            {
                birthPlace = "";
            }
            birthDate = DateTime.TryParse(adatok[4], out DateTime tempDate) ? tempDate : DateTime.MinValue;
        }

    }
    internal class Program
    {
        static void Main()
        {
            Feladat();
        }
        static void Feladat()
        {
            List<Kosarasok> data = File.ReadAllLines("kosarasok.csv").Skip(1).Select(ln => new Kosarasok(ln)).ToList();

            Console.WriteLine($"3. feladat: {data.Count()}");

            Console.WriteLine($"4. feladat: \t\n{string.Join("\t\n", data.Where(x => x.Nationality == "USA" && x.birthPlace == "").Select(x => $"{x.Name}"))}");

            Console.WriteLine("5. feladat: Adjon meg egy évszámot 1970 és 2000 között!");

            int year;

            while (true)
            {
                year = Convert.ToInt32(Console.ReadLine());
                if (year >= 1970 && year <= 2000)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hibás adat, kérek egy 1970 és 2000 közötti számot!");
                }
            }

            Console.WriteLine($"6. feladat: \t\n{data.Count(x => x.birthDate.Year == year)} fő");
        }
    }
}
