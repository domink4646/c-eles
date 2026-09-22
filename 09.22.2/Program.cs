using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._22._2
{
    public class Diakok
    {
        public string Nev { get; set; }
        public double Atlag { get; set; }
        public Diakok(string nev, double atlag)
        {
            Nev = nev;
            Atlag = atlag;
        }

        public Diakok(string ln)
        {
            string[] parts = ln.Split('\t');
            Nev = parts[0];
            Atlag = double.Parse(parts[1]);
        }


    }
    internal class Program
    {
        static void Main()
        {
            List<Diakok> data = File.ReadAllLines("erettsegizok.txt").Skip(1).Select(x => new Diakok(x)).ToList();
            Console.WriteLine($"{data.Count()}");
            Console.WriteLine($"{data.Average(x => x.Atlag).ToString("F2")}");
            Console.WriteLine($"{string.Join(", ", data.Where(x => x.Atlag == data.Max(f => f.Atlag)).Select(x => $"{x.Nev} - {x.Atlag}"))}");
            Console.WriteLine($"{(data.Any(x => x.Atlag == 5.00) ? "Van" : "Nincs")}");
            File.WriteAllText("atlagfelett.txt", $"{string.Join("\n", data.Where(x => x.Atlag > data.Average(f => f.Atlag)).Select(x => $"{x.Nev}"))}\n{data.Count(x => x.Atlag > data.Average(f => f.Atlag))}");
            Dictionary<string, int> dict = new Dictionary<string, int>() { ["elegtelen"] = 0, ["elegseges"] = 0, ["kozepes"] = 0, ["jo"] = 0, ["jeles"] = 0 };
            foreach (Diakok diakok in data)
            {
                if (diakok.Atlag < 2)
                {
                    dict["elegtelen"]++;
                }
                else if (diakok.Atlag < 3)
                {
                    dict["elegseges"]++;
                }
                else if (diakok.Atlag < 4)
                {
                    dict["jo"]++;
                }
                else if (diakok.Atlag < 4.5)
                {
                    dict["jeles"]++;
                }
            }
            Console.WriteLine($"\t{string.Join("\n\t", dict.Select(x => $"{x.Key} - {x.Value}"))}");
        }
    }
}
