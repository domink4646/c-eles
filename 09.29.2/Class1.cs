using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._29._2
{
    public enum PaymentMethod
    {
        bankkártya,
        készpénz,
        vitatott,
        ingyenes,
        ismeretlen
    }
    public class Fuvar
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int ETA { get; set; }
        public double Distance { get; set; }
        public double Fare { get; set; }
        public double Tip { get; set; }
        public PaymentMethod Method { get; set; }

        public double Income => Fare + Tip;


        public Fuvar(int id, DateTime start, int eTA, double distance, double fare, double tip, PaymentMethod method)
        {
            Id = id;
            Start = start;
            ETA = eTA;
            Distance = distance;
            Fare = fare;
            Tip = tip;
            Method = method;
        }
        public override string ToString()
        {
            return $"\n\tFuvar hossza: {Distance} másodperc\n\tTaxi azonosító: {Id}\n\tMegtett távolság: {(Distance * 1.6):F2} km\n\tViteldíj: {Fare}$";
        }
    }
}
