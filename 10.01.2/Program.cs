using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._01._2
{
    internal class Program
    {
        static void Main()
        {
            List<Eredmeny> data = File.ReadAllLines("kimi.csv").Skip(1).Select(ln => ln.Split(';').Select(x => new Eredmeny(DateTime.Parse(x[0]), x[1], int.Parse(x[2]), ));
        }
    }
}
