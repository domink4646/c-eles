using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _09._08
{
    internal class Program
    {
        public struct Fogadoora
        {
            public string tanar_Vezeteknev;
            public string tanar_Keresztnev;
            public DateTime idoPont;
            public string foglalas;
        }
        static void Main(string[] args)
        {
            Feladat();
        }
        static void Feladat()
        {
            List<Fogadoora> data = File.ReadAllLines("fogado.txt").Select(x => x.Split(' ')).Select(d => new Fogadoora
            {
                tanar_Vezeteknev = d[0],
                tanar_Keresztnev = d[1],
                idoPont = DateTime.Parse(d[2]),
                foglalas = d[3]
            }).ToList();

            Console.WriteLine($"Foglalások száma: {data.Count}");

            string keresettNev = Input<string>("Kérem a keresett tanár nevét (vezetéknév keresztnév): ").ToLower();

            var keresettFoglalasok = data.Where(x => (x.tanar_Vezeteknev + " " + x.tanar_Keresztnev).ToLower() == keresettNev).ToList();

            if (keresettFoglalasok.Count > 0)
            {
                Console.WriteLine($"A keresett tanár foglalásai:");
                keresettFoglalasok.ForEach(x => Console.WriteLine($"{x.idoPont:yyyy-MM-dd HH:mm} - {x.foglalas}"));
            }
            else
            {
                Console.WriteLine("Nincs foglalás a keresett tanárhoz.");
            }

            DateTime keresettFoglalas = Input<DateTime>("Kérem a keresett foglalás időpontját (xx:xx): ");

            var keresettTanarok = data.Where(x => x.idoPont.TimeOfDay == keresettFoglalas.TimeOfDay).OrderBy(x => x.tanar_Vezeteknev).ToList();

            StreamWriter sw = new StreamWriter("fogado_keresett.txt");

            keresettTanarok.ForEach(x => sw.WriteLine(x.tanar_Vezeteknev + " " + x.tanar_Keresztnev));

            sw.Close();

            int hanyFoglalas = data.Count(x => x.foglalas.StartsWith("2017.11.06"));

            Console.WriteLine($"2017.11.06-án {hanyFoglalas} foglalás történt.");

            var barnaEszter = data.Where(x => x.tanar_Vezeteknev == "Barna" && x.tanar_Keresztnev == "Eszter").ToList();

            int eltoltott_Ido = barnaEszter.Count * 10 / 60;

            Console.WriteLine("Barna Eszter fogadóóráinak időpontjai:");

            barnaEszter.ForEach(x => Console.WriteLine($"{x.idoPont:HH:mm}"));

            Console.WriteLine($"Barna Eszter összesen {eltoltott_Ido} órát töltött a fogadóórákon.");

        }
        static T Input<T>(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }
    }
}
