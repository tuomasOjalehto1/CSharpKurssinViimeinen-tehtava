using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Tehtävänä on laskea pankkisiirtojen viitteistä tuttu tarkistenumero ja
tulostaa viitenumero ryhmiteltynä.

Alla on esimerkki laskemisesta. Lasketaan runko-osalle 12345 tarkistenumero:

          runko-osa     1     2     3     4     5
     painokertoimet     3     7     1     3     7
                        -------------------------
              tulot     3    14     3    12    35

näiden tulojen summa on 67

Siis oikealta alkaen kerrotaan numerot vuorollaan painoilla 
7, 3, 1, 7, 3, 1, 7, ... jne

Tarkistenumero on tulojen summa vähennettynä seuraavasta täydestä 
kymmenestä (paitsi jos summa on tasakymmeniä, on tarkiste nolla). 

Esimerkin tapauksessa siis tarkiste on 3. 

Alkuperäinen runko-osa ja tarkiste tulostetaan ruudulle näin: oikeanpuoleisimpaan 
ryhmään neljä + tarkiste, muihin viisi merkkiä ja ekaan niin monta kuin riittää

Ohjelman tulisi toimia seuraavasti:

Anna viitteen runko-osa : 325308000102798049011

Viitenumero : 32 53080 00102 79804 90117
*/
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Projekti
{
    class MyProgram
    {


        public static int[] LuoTauluFunc(string sRunko)
        {

            //Poistetaan välilyönnit jos on
            sRunko = sRunko.Replace(" ", "");


            int[] runko;


            runko = new int[sRunko.Length];


            for (int i = 0; i < sRunko.Length; i++)
            {
                if (int.TryParse(sRunko[i].ToString(), out int numero))
                {
                    runko[i] = numero;
                }
                else
                {
                    return null;
                }
            }
            return runko;
        }

        public static int[] Laske(int[] runko)
        {
            int[] painokertoimet1 = new int[] { 7, 3, 1 };
            int[] painokertoimet2 = new int[runko.Length];

            for (int i = 0; i < runko.Length; i++)
            {
                painokertoimet2[i] = painokertoimet1[i % painokertoimet1.Length];
            }

            //Käännetään taulu
            Array.Reverse(runko);


            int[] lasketuttaulu = new int[runko.Length];


            for (int i = 0; i < runko.Length; i++)
            {
                lasketuttaulu[i] = runko[i] * painokertoimet2[i];
            }
            //Käännetään taas
            Array.Reverse(lasketuttaulu);
            return lasketuttaulu;
        }

        static int[] Tulostus(int[] runko, int tarkiste)
        {
            //Käänetään runko tässä kohtaa
            Array.Reverse(runko);

            List<int> tempList = new List<int>(runko);
            tempList.Add(tarkiste);

            return tempList.ToArray();
        }

        /*Tämä ei ollut ihan helppoa saada toimimaan johdonmukaisesti eripituisilla luvuilla */
        static string FormatoiViitenumeroFunc(string sRunko)
        {
            // Tarkistetaan runko merkkien varalta
            sRunko = new string(sRunko.Where(c => char.IsDigit(c)).ToArray());

            // lasketaan tarkiste
            int[] runko = LuoTauluFunc(sRunko);
            int[] laskettutaulu = Laske(runko);
            int summa = laskettutaulu.Sum();
            int lähinkymppi = (int)Math.Ceiling(summa / 10.0) * 10;
            int tarkiste = lähinkymppi - summa;

            // Lisätään tarkiste loppuun
            runko = Tulostus(runko, tarkiste);

            // Järjestellään runko blokkeihin ja lisätään välit.
            string formattedRunko = string.Join(" ", runko
                .Reverse() // Käännetään taas
                .Select((digit, index) => new { digit, index })
                .GroupBy(x => x.index / 5)
                .Select(group => new string(group.Select(x => x.digit.ToString()[0]).Reverse().ToArray()))
                .Reverse());

            return formattedRunko;
        }


        static void Main()
        {
            string sRunko;
            int[] runko;
            int[] laskettutaulu;
            Console.WriteLine("Anna viitteen runko- osa:");
            sRunko = Console.ReadLine();
            runko = LuoTauluFunc(sRunko);
            laskettutaulu = Laske(runko);

            //Console.WriteLine("Tulot");
            /*foreach (int num in laskettutaulu)
            {
                Console.Write(num + " ");
            }*/

            int summa = laskettutaulu.Sum();
            //int lähinkymppi = (summa + 5) / 10 * 10;
            int lähinkymppi = (int)Math.Ceiling(summa / 10.0) * 10; //Lasketaan lähimpään kymppiin
            int tarkiste = lähinkymppi - summa;
            //Console.WriteLine("Tarkiste: " +tarkiste);

            runko = Tulostus(runko, tarkiste);

            string formattedViitenumero = FormatoiViitenumeroFunc(sRunko);

            Console.WriteLine("Viitenumero : " + formattedViitenumero);
            /*foreach (int num in runko)
            {
                Console.Write(num + " ");
            }*/

        }
    }
}