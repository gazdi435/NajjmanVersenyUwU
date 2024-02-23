using System.ComponentModel;
using System.IO;
namespace verseny
{
    internal class Program
    {
        public static string megadottSzam;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //1. alpont
            List<long> list = File.ReadAllLines("szamok.txt").ToList().ConvertAll(x => Convert.ToInt64(x)); //szerettel daninak
                                                                                                            //StreamReader sw = new StreamReader("szamok.txt");
                                                                                                            //List<long> list = new List<long>();
                                                                                                            //while (!sw.EndOfStream) {

            //}


            //a
            /*A fájlban tárolt számok között hány olyan szerepel, amely a 1310438493 számmal relatív prím?
            Két számot relatív prímnek nevezünk, ha legnagyobb közös osztójuk 1.
            Pl.: a 10 és a 21 relatív prímek (bár egyik sem prímszám).
            Beküldendő egy szám (a válasz a kérdésre)*/
            int szam = 1310438493;
            List<int> osztok = new List<int>();
            // megadott szam LNKO-ja
            while (szam > 1)
            {
                for (int i = 2; i < szam + 1; i++)//bananá
                {
                    if (szam % i == 0)
                    {
                        Console.WriteLine($"dibag: {szam} % {i} = {szam % i}");
                        szam = szam / i;
                        osztok.Add(i);
                        break;
                    }
                }
            }
            Console.WriteLine($"Legnagyobb osztó: {osztok.Max()}");



            //b

            megadottSzam = "2354211341";
            Console.WriteLine(list.Distinct().ToList().Count(x => Ellenoriz(x)));


        }

        public static bool Ellenoriz(long adat)
        {
            string adatString = Convert.ToString(adat);
            for (int i = 0; i < adatString.Length; i++)
            {
                if (adatString[i] != megadottSzam[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}