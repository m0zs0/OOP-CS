using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NASA
{
    internal class Keres
    {
        public Keres(string s)
        {
            string [] seged = s.Split('*');
            Cim = seged[0];
            DatumIdo = DateTime.ParseExact(seged[1], "dd/MMM/yyyy:HH:mm:ss", CultureInfo.InvariantCulture); 
            Get = seged[2];
            HttpKod = seged[3].Split()[0];
            Meret = seged[3].Split()[1];
        }

        public string Cim { get; set; }
        public DateTime DatumIdo { get; set; }
        public string Get { get; set; }
        public string HttpKod { get; set; }
        public string Meret { get; set; }

        public int ByteMeret 
        {
            get
            {
                if (Meret == "-") return 0;
                return int.Parse(Meret);
            }
        }

        public bool Domain 
        {
            get
            {
                if (Char.IsLetter(Cim[Cim.Length - 1])) return true;
                else return false;
            }
        }

        public override string ToString()
        {
            return $"címe: {Cim} ideje: {DatumIdo} állapotkód: {HttpKod} méret: {Meret}";
        }

    }
}
