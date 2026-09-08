using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._08._2
{
    internal class Program
    {
        public struct Nevek
        {
            public string iskolakezdes_Eve;
            public char osztaly;
            public string nev;
        }
        static void Main()
        {
            Feladat();
        }
        static void Feladat()
        {
            List<Nevek> nevek = File.ReadAllLines("nevek.txt").Select(ln => ln.Split(';')).Select(x => new Nevek
            {
                iskolakezdes_Eve = x[0],
                osztaly = char.Parse(x[1]),
                nev = x[2]
            }).ToList();

            Console.WriteLine($"{nevek.Count} tanuló jár az iskolába.");

            var leghosszabbNevuTanulo = nevek.Select(x => x.nev).OrderByDescending(n => n.Length).First();

            string lNev = leghosszabbNevuTanulo.Replace(" ", "");

            Console.WriteLine($"A leghosszabb nevű tanuló: {lNev} ({lNev.Length} karakter)");

            var azonositok = nevek.Select(x => $"{x.iskolakezdes_Eve[3]}{x.osztaly}{x.nev.Split(' ')[0].Substring(0, 3).ToLower()}{x.nev.Split(' ')[1].Substring(0, 3).ToLower()} {x.nev}").ToList();

            Console.WriteLine($"Első azonosító + név: [{azonositok.First()}]");
            Console.WriteLine($"Utolsó azonosító + név: [{azonositok.Last()}]");

            string keresettEv = Input<string>("Kérem a keresett évszámot: ");

            var keresettEvTanulok = nevek.Where(x => x.iskolakezdes_Eve == keresettEv).ToList();

            StreamWriter sw = new StreamWriter($"ev{keresettEv}.txt");

            keresettEvTanulok.ForEach(x => sw.WriteLine(x));

            sw.Close();

            string keresettAzonosito = Input<string>("Adja meg a keresett azonosítót!");

            
        }
        static T Input<T>(string message)
        {
            Console.Write(message);
            return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
        }
    }
}
