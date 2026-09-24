using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _09._24
{
    public class Balkezesek
    {
        public string Nev { get; private set; }
        public DateTime PalyaralepesElso { get; private set; }
        public DateTime PalyaralepesUtolso { get; private set; }
        public int Suly { get; private set; }
        public int Magassag { get; private set; }

        public Balkezesek(string line)
        {
            string[] adatok = line.Split(';');

            Nev = adatok[0];
            PalyaralepesElso = DateTime.Parse(adatok[1]);
            PalyaralepesUtolso = DateTime.Parse(adatok[2]);
            Suly = int.Parse(adatok[3]);
            Magassag = int.Parse(adatok[4]);
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<Balkezesek> data = File.ReadAllLines("balkezesek.csv")
                .Skip(1)
                .Select(line => new Balkezesek(line))
                .ToList();

            Console.WriteLine(
                $"3. feladat: {data.Count} db balkezes szerepel az adatállományban."
            );

            var playersFromOctober1999 = data
                .Where(player =>
                    player.PalyaralepesUtolso.Year == 1999 &&
                    player.PalyaralepesUtolso.Month == 10);

            Console.WriteLine("4. feladat:");

            foreach (Balkezesek player in playersFromOctober1999)
            {
                double heightInCentimeters = player.Magassag * 2.54;

                Console.WriteLine(
                    $"{player.Nev} - {heightInCentimeters:F1} cm"
                );
            }

            int year;

            do
            {
                year = InputInt("Adjon meg egy évszámot 1990 és 1999 között!");
            }
            while (year < 1990 || year > 1999);

            Console.WriteLine($"6. feladat: {string.Join("\t\n", data.Where(x => x.PalyaralepesElso.Year == year).Average(x => x.Suly).ToString("F2"))}");
        }

        public static int InputInt(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    return number;
                }

                Console.WriteLine("Hibás adat! Egész számot adjon meg.");
            }
        }
    }
}