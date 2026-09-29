using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._29
{
    public class Country
    {
        public string Name { get; set; }
        public DateTime joinDate { get; set; }

        public Country(string ln)
        {
            string[] parts = ln.Split(';');
            Name = parts[0];
            joinDate = DateTime.Parse(parts[1]);
        }

        public Country(string name, DateTime joinDate)
        {
            Name = name;
            this.joinDate = joinDate;
        }
    }
}
