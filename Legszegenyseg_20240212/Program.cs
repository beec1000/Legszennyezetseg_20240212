using Microsoft.VisualBasic;

namespace Legszegenyseg_20240212
{
    internal class Program
    {
        static List<int> F3(List<Legszennyezettseg> l)
        {
            var x = new List<int>();
            foreach (var i in l)
            {
                if (i.Orak.Any(d => d > 250))
                {
                    x.Add(i.Napok);
                }
            }
            return x;
        }

        static int F4(List<Legszennyezettseg> l) => l.SelectMany(d => d.Orak).Max();

        static int F5(List<Legszennyezettseg> l) => l.Sum(d => d.Orak.Where(d => d < 100).Count());

        static double F6(List<Legszennyezettseg> l) => l.SelectMany(d => d.Orak).Average();

        static Legszennyezettseg F7(List<Legszennyezettseg> l) => l.FirstOrDefault(day => day.Orak.Max() <= 60);

        static void Main(string[] args)
        {
            List<Legszennyezettseg> szennyezettseg = new List<Legszennyezettseg>();
            using StreamReader sr = new StreamReader(@"..\..\..\src\SO2.txt");
            for (int i = 1; !sr.EndOfStream; i++)
            {
                szennyezettseg.Add(new Legszennyezettseg(i, sr.ReadLine()));
            }

            //2. feladat
            foreach (var i in szennyezettseg)
            {
                Console.WriteLine(i);
            }

            //3. feladat
            using StreamWriter sw = new StreamWriter(@"..\..\..\src\UjSO2.txt");
            if (F3(szennyezettseg).Count > 0)
            {
                foreach (var i in F3(szennyezettseg))
                {
                    sw.WriteLine($"Március {i}.");
                }
            }
            else
            {
                Console.WriteLine("HIBA 404!!! Nincs olyan nap");
            }

            Console.WriteLine("4. feladat");
            Console.WriteLine($"A legmagasabb SO2 tartalom {F4(szennyezettseg)} volt.");

            Console.WriteLine("5. feladat");
            Console.WriteLine($"Összesen {F5(szennyezettseg)} olyan óra volt.");

            Console.WriteLine("6. feladat");
            Console.WriteLine($"Az átlagos SO2 tartalom a hónapban: {Math.Round(F6(szennyezettseg), 4)}");

            Console.WriteLine("7. feladat");
            if (F7(szennyezettseg) != null)
            {
                Console.WriteLine($"{F7(szennyezettseg).Napok}. Napon volt.");
            }
            else
            {
                Console.WriteLine("HIBA 404!!! Nem Volt ilyen!");
            }
        }
    }
}