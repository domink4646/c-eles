using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._19
{
    public class Weekend
    {
        public string eredetiCim { get; private set; }
        public string magyarCim { get; private set; }
        public DateTime bemutato { get; private set; }
        public string forgalmazo { get; private set; }
        public long bevetel { get; private set; }
        public int latogatokSzama { get; private set; }
        public Weekend(string ln)
        {
            string[] arr = ln.Split(';');
            eredetiCim = arr[0];
            magyarCim = arr[1];
            bemutato = DateTime.Parse(arr[2]);
            forgalmazo = arr[3];
            bevetel = long.Parse(arr[4]);
            latogatokSzama = int.Parse(arr[5]);
        }

        public override string ToString()
        {
            return $"\n\tEredeti cím: {eredetiCim}\n\tMagyar cím: {magyarCim}\n\tForgalmazó: {forgalmazo}\n\tBevétel az első héten: {bevetel} Ft\n\tLátogatók száma: {latogatokSzama} fő";
        }
    }

}
