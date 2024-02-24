using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace verseny
{
    internal class Telepules
    {
        public int Iranyitoszam { get; set; }
        public string MegyeAzonosito { get; set; }
        public double SzelsesegiKoordinata { get; set; }
        public double HosszusagiKoordinata { get; set; }
        public double Terulet { get; set; }
        public int LakosokSzama { get; set; }
        public string TelepulesNev { get; set; }
        public int TavolsagKecskemetto { get; set; }
        public int TavolsagSzegedto { get; set; }

        public Telepules(string sor)
        {
            string[] adatok = sor.Split(' ');

            Iranyitoszam = Convert.ToInt32(adatok[0]);
            MegyeAzonosito = adatok[1];
            SzelsesegiKoordinata = Telepules.stringToDouble(adatok[2]);
            HosszusagiKoordinata = Telepules.stringToDouble(adatok[3]);
            Terulet = Telepules.stringToDouble(adatok[4]);
            LakosokSzama = Convert.ToInt32(adatok[5]);
            TelepulesNev = adatok[6];
            TavolsagKecskemetto = Convert.ToInt32(adatok[7]);
            TavolsagKecskemetto = Convert.ToInt32(adatok[8]);
        }
        public bool benneVanE()
        {
            bool kecskemettol=false;
            bool szegedtol = false;
            if (this.TavolsagKecskemetto<=50)
            {
                kecskemettol = true;
            }
            if (this.TavolsagSzegedto<=50)
            {
                szegedtol = true;
            }

            if (kecskemettol && szegedtol)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{this.Iranyitoszam} {this.MegyeAzonosito} {this.SzelsesegiKoordinata} {this.HosszusagiKoordinata} {this.Terulet} {this.LakosokSzama} {this.TelepulesNev} {this.TavolsagKecskemetto} {this.TavolsagSzegedto}";
        }
        public static double stringToDouble(string szoveg)
        {
            List<int> lista = szoveg.Split(".").ToList().ConvertAll(x => Convert.ToInt32(x));
            return (lista[0] + lista[1] / Math.Pow(10, Convert.ToDouble(szoveg.Split(".")[1].Length)));

        }

        public static List<Telepules> ConvertToTelepulesList(List<string> sorok)
        {
            List<Telepules> telepulesek = new List<Telepules>();

            foreach (string sor in sorok)
            {
                Telepules telepules = new Telepules(sor);
                telepulesek.Add(telepules);
            }

            return telepulesek;
        }
    }
}
