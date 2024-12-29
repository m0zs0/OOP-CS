using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezerLovesek
{
    class Loves
    {
        public static double KozepX { get; set; }
        public static double KozepY { get; set; }

        public Loves()
        {
        }

        public Loves(string nev, double x, double y, int id)
        {
            this.Nev = nev;
            this.X = x;
            this.Y = y;
            this.Id = id;
        }

        public string Nev { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int Id { get; set; }

        public double Tavolsag()
        {
            double dx = KozepX - this.X;
            double dy = KozepY - this.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public double Pontszam
        {
            get
            {
                double pontszam = 10 - this.Tavolsag();
                if (pontszam<0)
                {
                    return 0;
                }
                return pontszam;
            }
            set
            {
               
            }
        }
    }
}