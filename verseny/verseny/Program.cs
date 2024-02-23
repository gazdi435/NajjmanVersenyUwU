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
            Pl.: a 10 és a 21 relatív prímek (bár egyik sem prímszám). xDDDD
            Beküldendő egy szám (a válasz a kérdésre) */
            int szam = 1310438493;
            List<long> relativ_primek = new List<long>();
            List<long> szamosztoi = osztok(szam);
            foreach( long l in list )
            {
                List<long> vizsgaltszam_osztoi = osztok(l);
                if (!szamosztoi.Intersect(vizsgaltszam_osztoi).Any()) {
                    relativ_primek.Add(l);
                    Console.WriteLine($"relativ prim: {l}");
                }
            }
            Console.WriteLine($"{szam} relatív prímei ({relativ_primek.Count})");


            //b

            megadottSzam = "2354211341";
            Console.WriteLine(list.Distinct().ToList().Count(x => Ellenoriz(x)));


            //2. feladatat
            //a)
            List<List<string>> megyekList = File.ReadAllLines("telepules.txt").Select(x=> x.Split("").ToList()).ToList();
            //Dictionary<string, string> megyekDic = File.ReadAllLines("megyek.txt").Select(x => x.Split("").ToDictionary(string,string)).ToList();

            List<string> megoldas = megyekList.OrderByDescending(x => Convert.ToInt16(x[5])).ToList()[1];
            Console.WriteLine(megyekList.OrderByDescending(x => Convert.ToInt16(x[5])).ToList()[1]);



        }
        public static List<long> osztok(long szam)
        {
            List<long> osztok_list = new List<long>();
            while (szam > 1)
            {
                for (int i = 2; i < szam + 1; i++)//bananá
                {
                    if (szam % i == 0)
                    {
                        //Console.WriteLine($"dibag: {szam} % {i} = {szam % i}");
                        szam = szam / i;
                        osztok_list.Add(i);
                        break;
                    }
                }
            }
            return osztok_list;
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