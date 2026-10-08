using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._08._2
{
    public class Tenisz
    {
        public string Torna { get; private set; }
        public DateTime Datum { get; private set; }
        public string Burkolat { get; private set; }
        public string Eredmeny { get; private set; }
        public string gyoztesNeve { get; private set; }
        public int gyoztesMagassaga { get; private set; }
        public string gyoztesNemzetisege { get; private set; }
        public double gyoztesEletkora { get; private set; }
        public string vesztesNeve { get; private set; }
        public int vesztesMagassaga { get; private set; }
        public string vesztesNemzetisege { get; private set; }
        public double vesztesEletkora { get; private set; }

        public Tenisz(string line)
        {
            string[] parts = line.Split(';');
            Torna = parts[0];
            Datum = DateTime.Parse(parts[1]);
            Burkolat = parts[2];
            Eredmeny = parts[3];
            gyoztesNeve = parts[4];
            gyoztesMagassaga = int.TryParse(parts[5], out int result) ? result : 0;
            gyoztesNemzetisege = parts[6];
            gyoztesEletkora = double.Parse(parts[7]);
            vesztesNeve = parts[8];
            vesztesMagassaga = int.TryParse(parts[9], out int res) ? res : 0;
            vesztesNemzetisege = parts[10];
            vesztesEletkora = double.Parse(parts[11]);
        }

        public override string ToString()
        {
            return $"{Torna};{Datum};{Burkolat};{Eredmeny};{gyoztesNeve};" +
                   $"{gyoztesMagassaga};{gyoztesNemzetisege};{gyoztesEletkora};" +
                   $"{vesztesNeve};{vesztesMagassaga};{vesztesNemzetisege};" +
                   $"{vesztesEletkora}";
        }

    }
}
