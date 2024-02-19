using Microsoft.VisualBasic;

namespace Legszegenyseg_20240212
{
    internal class Program
    {
        static Legszennyezettseg F3(List<Legszennyezettseg> l)
        {
            var x = l.MaxBy(d => d.Orak.Max());
            
            return x;

        }

        static int F4(List<Legszennyezettseg> l) => l.SelectMany(d => d.Orak).Max();

        static int F5(List<Legszennyezettseg> l) => l.Sum(d => d.Orak.Where(d => d < 100).Count());

        static double F6(List<Legszennyezettseg> l) => l.SelectMany(d => d.Orak).Average();

        static List<int> F7(List<Legszennyezettseg> l)
        {
            var x = l.Select(d => d.Orak.Max()).ToList();
            List<int> y;
            foreach (var i in x)
            {
                if (i <= 60)
                {
                    y.Add(i);
                }
            }
        }

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
            sw.WriteLine($"{F3(szennyezettseg).Napok} |");



            Console.WriteLine("4. feladat");
            Console.WriteLine($"A legmagasabb SO2 tartalom {F4(szennyezettseg)} volt.");

            Console.WriteLine("5. feladat");
            Console.WriteLine($"Összesen {F5(szennyezettseg)} olyan óra volt.");

            Console.WriteLine("6. feladat");
            Console.WriteLine($"Az átlagos SO2 tartalom a hónapban: {Math.Round(F6(szennyezettseg), 4)}");

            Console.WriteLine("7. feladat");
            foreach (var i in F7(szennyezettseg))
            {
                if (i <= 60)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}