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
                
            }
            birthDate = DateTime.Parse(adatok[4]);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kosarasok> data = File.ReadAllLines("kosarasok.csv").Skip(1).Select(ln => new Kosarasok(ln)).ToList();

            Console.WriteLine($"3. feladat: {data.Count()}");
            Console.WriteLine($"4. feladat: {string.Join("\t\n", data.Where(x => x.Nationality == "USA" && x.birthPlace == "").Select(x => $"{x.Name}"))}");

        }
    }
}
