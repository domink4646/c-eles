using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._22
{
    public class Tanar
    {
        public string Nev { get; private set; }
        public string Szak { get; private set; }
        public string Kor { get; private set; }
        public int Fizetes { get; private set; }
        public int Tapasztalat { get; private set; }

        public Tanar(string ln)
        {
            string[] strings = ln.Split(';');
            Nev = strings[0];
            Szak = strings[1];
            Kor = strings[2];
            Fizetes = int.Parse(strings[3]);
            Tapasztalat = int.Parse(strings[4]);
        }
    }
    internal class Program
    {
        static void Main()
        {
            List<Tanar> data = File.ReadAllLines("tanarok.txt").Skip(1).Select(x => new Tanar(x)).ToList();
            Console.WriteLine($"{data.Count()}");
            Console.WriteLine($"{data.Count(x => x.Szak.Equals("Informatika"))}");
            Console.WriteLine($"{string.Join(",",data.Where(x => x.Kor == data.Max(f => f.Kor)).Select(x => $"{x.Nev} - {x.Kor}"))}");
            Console.WriteLine($"{data.Average(x => x.Fizetes)}");
            Console.WriteLine($"{string.Join(",", data.Where(x => x.Tapasztalat == data.Min(f => f.Tapasztalat)).Select(x => $"{x.Nev} - {x.Szak} - {x.Kor} - {x.Fizetes} - {x.Tapasztalat}"))}");
        }
    }
}
