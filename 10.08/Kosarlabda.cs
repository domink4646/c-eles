using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._08
{
    public class Kosarlabda
    {
        public string Hazai { get; private set; }
        public string Idegen { get; private set; }
        public int hazaiPont { get; private set; }
        public int idegenPont { get; private set; }
        public string Helyszin { get; private set; }
        public DateTime Idopont { get; private set; }

        public Kosarlabda(string hazai, string idegen, int hazaiPont, int idegenPont, string helyszin, DateTime idopont)
        {
            Hazai = hazai;
            Idegen = idegen;
            this.hazaiPont = hazaiPont;
            this.idegenPont = idegenPont;
            Helyszin = helyszin;
            Idopont = idopont;
        }
    }
}
