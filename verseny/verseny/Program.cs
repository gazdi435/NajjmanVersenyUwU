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
            var ismetlodok = list.GroupBy(x => x).Where(g => g.Count() > 1).SelectMany(g => g);

            // Az ismétlődő elemek eltávolítása a listából
            list.RemoveAll(x => ismetlodok.Contains(x));

            //a
            /*A fájlban tárolt számok között hány olyan szerepel, amely a 1310438493 számmal relatív prím?
            Két számot relatív prímnek nevezünk, ha legnagyobb közös osztójuk 1.
            Pl.: a 10 és a 21 relatív prímek (bár egyik sem prímszám). xDDDD
            Beküldendő egy szám (a válasz a kérdésre) */
            int szam = 1310438493;
            List<long> relativ_primek = new List<long>();
            /*List<long> szamosztoi = osztok(szam);
            foreach( long l in list )
            {
                List<long> vizsgaltszam_osztoi = osztok(l);
                if (!szamosztoi.Intersect(vizsgaltszam_osztoi).Any()) {
                    relativ_primek.Add(l);
                    Console.WriteLine($"relativ prim: {l}");
                }
            }
            Console.WriteLine($"{szam} relatív prímei ({relativ_primek.Count})");*/

            foreach (long l in list)
            {
                
                if (LNKO_szamitas(szam, l) == 1)
                {
                    relativ_primek.Add(l);
                    Console.WriteLine($"relativ prim: {l}");
                }
            }
            Console.WriteLine($"{szam} relatív prímei ({relativ_primek.Count})");


            //b

            
            long szam2 = 2354211341;
            List<long> anagrammak = new List<long>();
            //Console.WriteLine(list.Distinct().ToList().Count(x => Ellenoriz(x)));
            List<int> szamok = new List<int>();
            for (int i = 0; i < szam2.ToString().Length; i++)
            {
                szamok.Add(int.Parse(szam2.ToString()[i].ToString()));
            }
            szamok.Sort();
            foreach (long l in list)
            {
                if (l!=szam2)
                {
                    List<int> beolvasottszamok = new List<int>();
                    for (int i = 0; i < l.ToString().Length; i++)
                    {
                        beolvasottszamok.Add(int.Parse(l.ToString()[i].ToString()));
                    }
                    beolvasottszamok.Sort();
                    if (szamok.SequenceEqual(beolvasottszamok))
                    {
                        anagrammak.Add(l); Console.WriteLine($"talalat: {l}");
                    }
                }
                
                
                
            }
            Console.WriteLine($"Anagrammak szama: {anagrammak.Count}");

            //c

            Dictionary<int, int> elofordulas = new Dictionary<int, int>(){};



            long szam3 = 34234521;

            //List<int> ketjegyuSzamok = KeresKetjegyuSzamok(szam3);

            //Console.WriteLine($"A(z) {szam3} számban előforduló kétjegyű számok: {string.Join(", ", ketjegyuSzamok)}");
            foreach  (long l in list)
            {
                List<int> ketjegyuSzamok = KeresKetjegyuSzamok(l);
                foreach (var item in ketjegyuSzamok)
                {
                    if (elofordulas.ContainsKey(item))
                    {
                        elofordulas[item]++;
                    }
                    else
                    {
                        elofordulas.Add(item, 1);
                    }
                }
            }
            foreach (var kvp in elofordulas)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            int maxErtek = elofordulas.Values.Max();

            int kulcs = elofordulas.FirstOrDefault(x => x.Value == maxErtek).Key;
            Console.WriteLine($"A leggyakoribb: {kulcs} ({maxErtek})");


            //VÁLASZOK: a) 1457 b) 26 c) 12


            //2. feladatat
            //a)
            List<List<string>> megyekList = File.ReadAllLines("telepules.txt").Select(x=> x.Split("").ToList()).ToList();
            //Dictionary<string, string> megyekDic = File.ReadAllLines("megyek.txt").Select(x => x.Split("").ToDictionary(string,string)).ToList();

            /*List<string> megoldas = megyekList.OrderByDescending(x => Convert.ToInt16(x[5])).ToList()[1];
            Console.WriteLine(megyekList.OrderByDescending(x => Convert.ToInt16(x[5])).ToList()[1]);*/



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
        static long LNKO_szamitas(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        static List<int> KeresKetjegyuSzamok(long szam)
        {
            List<int> ketjegyuSzamok = new List<int>();
            string szamString = szam.ToString();

            for (int i = 0; i < szamString.Length - 1; i++)
            {
                int ketjegyuSzam = int.Parse(szamString.Substring(i, 2));
                ketjegyuSzamok.Add(ketjegyuSzam);
            }

            return ketjegyuSzamok;
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