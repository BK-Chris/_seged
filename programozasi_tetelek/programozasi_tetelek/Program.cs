







/** Alapvető programozási tételek
 * CTRL + LMB -el oda ugrik a függvényhez (Visual Studio 2022-ben)
 *
 */
namespace programozasi_tetelek
{
    internal class Program
    {
        static void Main()
        {
            // Összegzés
            Console.WriteLine("Osszegzes tetel");
            int[] osztalyok = { 25, 20, 15 };
            TombKiirasa(osztalyok);
            Console.WriteLine($"Osztalyok letszama: {Osszegzes(osztalyok)}\n");


            // Megszámolás
            Console.WriteLine("Megszamolas tetel");
            int[] homersekletiAdatok = {
                1, 2, 0, -1, -3, -2, 1, 3, 5, 4,
                3, 2, 0, -2, -4, -5, -3, -1, 0, 2,
                4, 6, 5, 3, 1, 0, -1, -2
            };
            TombKiirasa(homersekletiAdatok);
            Console.WriteLine($"Az adatok alapján {Megszamolas(homersekletiAdatok)} -szer fagyott.\n");


            // Maximum kiválasztás
            Console.WriteLine("Maximum kivalasztas tetel");
            int[] magassagok = { 165, 175, 158, 201, 173, 205 };
            TombKiirasa(magassagok);
            int[] ertekek = MaximumKivalasztas(magassagok);
            Console.WriteLine($"A legmagasabb ember {ertekek[0] + 1}. indexen {ertekek[1]} volt.\n");


            // Minimum kiválasztás
            Console.WriteLine("Maximum kivalasztas tetel");
            TombKiirasa(magassagok);
            ertekek = MinimumKivalasztas(magassagok);
            Console.WriteLine($"A legalacsonyabb ember {ertekek[0] + 1}. indexen {ertekek[1]} volt.\n");


            // Feltételes maximum keresés
            Console.WriteLine("Felteteles maximum kereses tetel");
            TombKiirasa(homersekletiAdatok);
            FeltetelesMaximumKivalasztas(homersekletiAdatok);


            // Keresés
            Console.WriteLine("\nKereses tetel");
            TombKiirasa(homersekletiAdatok);
            Console.WriteLine($"Volt-e 10 fok a homersekleti adatokban?");
            Kereses(homersekletiAdatok, 10);
            Console.WriteLine($"Volt-e -1 fok a homersekleti adatokban?");
            Kereses(homersekletiAdatok, -1);


            // Eldöntés
            Console.WriteLine("\nEldontes tetel");
            Console.Write("13 az primszam? ");
            if (Primszam(13))
                Console.Write("Igen!\n");
            else
                Console.Write("Nem!\n");
            Console.Write("21 az primszam? ");
            if (Primszam(21))
                Console.Write("Igen!\n");
            else
                Console.Write("Nem!\n");

            // Mind eldöntés
            Console.WriteLine("\nMind eldontes tetel");
            int[] primek = { 3, 5, 7, 11, 13, 17, 19 };
            TombKiirasa(primek);
            MindPrimszam(primek);

            int[] nemMindPrimek = { 3, 5, 7, 11, 13, 17, 21 };
            TombKiirasa(nemMindPrimek);
            MindPrimszam(nemMindPrimek);


            //Kiválasztás
            Console.WriteLine("\nKiválasztás tétel");
            Kivalaszt("VII");

        }

        private static void Kivalaszt(string kartya)
        {
            string[] kartyak = new string[8] { "VII", "VIII", "IX", "X", "Also", "Felso", "Kiraly", "Asz" };
            int[] ertekek = new int[8] { 7, 8, 9, 10, 2, 3, 4, 11 };

            int i = 0;
            while(i < kartyak.Length && kartyak[i] != kartya)
                i++;
            if(i != ertekek.Length)
            {
                Console.WriteLine($"A {kartyak[i]} értéke: {ertekek[i]} és indexe: {i+1}");
            }
            else
            {
                Console.WriteLine("Sajnos nem létezik ilyen kártya!");
            }
        }

        private static void MindPrimszam(int[] szamok)
        {
            int i = 0;
            while (i < szamok.Length && Primszam(szamok[i]))
                i++;
            if(i == szamok.Length)
            {
                Console.WriteLine("Valóban mind prímszám!");
            } else
            {
                Console.WriteLine("Sajnos nem mind prímszám!");
            }
        }

        private static bool Primszam(int szam)
        {
            int szamGyoke = (int)Math.Sqrt(szam);
            int i = 2;
            while (i <= szamGyoke && szam % i != 0)
                i++;
            return (i > szamGyoke);
        }

        private static void Kereses(int[] elemek, int elem)
        {
            int i = 0;
            while ((i < elemek.Length) && elemek[i] != elem)
                i++;
            if (i != elemek.Length)
            {
                Console.WriteLine($"Igen volt még pedig itt: {i + 1}.");
            }
            else
            {
                Console.WriteLine($"Sajnos nem volt ilyen elem!");
            }
        }

        private static void FeltetelesMaximumKivalasztas(int[] elemek)
        {
            bool van = false;
            int maxind = -1;
            int maxert = -1;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] < 0)
                {
                    if (van)
                    {
                        if (elemek[i] > elemek[maxind])
                        {
                            maxind = i;
                            maxert = elemek[i];
                        }
                    }
                    else
                    {
                        van = true;
                        maxind = i;
                        maxert = elemek[i];
                    }
                }
            }
            if (van)
            {
                Console.WriteLine($"Legnagyobb indexe: {maxind + 1} ennek az értéke: {maxert}.");
            }
            else
            {
                Console.WriteLine($"Sajnos nem volt a feltetelnek megfelelo elem.");
            }
        }

        private static int[] MinimumKivalasztas(int[] elemek)
        {
            int minIndex = 0;
            int minErtek = elemek[0];
            for (int i = 1; i < elemek.Length; i++)
            {
                if (elemek[i] < minErtek)
                {
                    minIndex = i;
                    minErtek = elemek[i];
                }
            }
            return new int[] { minIndex, minErtek };
        }

        private static int[] MaximumKivalasztas(int[] elemek)
        {
            int maxIndex = 0;
            int maxErtek = elemek[0];
            for (int i = 1; i < elemek.Length; i++)
            {
                if (elemek[i] > maxErtek)
                {
                    maxIndex = i;
                    maxErtek = elemek[i];
                }
            }
            return new int[] { maxIndex, maxErtek };
        }

        static int Megszamolas(int[] elemek)
        {
            int darab = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] < 0)
                {
                    darab++;
                }
            }
            return darab;
        }

        static int Osszegzes(int[] elemek)
        {
            int ossz = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                ossz += elemek[i];
            }
            return ossz;
        }

        static void TombKiirasa<T>(T[] tomb)
        {
            Console.Write("Tomb elemei: ");
            foreach (var t in tomb)
            {
                Console.Write($"{t} ");
            }
            Console.Write("\n");
        }
    }
}