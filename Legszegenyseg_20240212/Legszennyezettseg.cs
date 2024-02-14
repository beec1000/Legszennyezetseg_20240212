using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legszegenyseg_20240212
{
    internal class Legszennyezettseg
    {
        public int Napok { get; set; }
        public List<int> Orak { get; set; }

        public Legszennyezettseg(int n, string s)
        {
            string[] v = s.Split(';');
            this.Napok = n;
            this.Orak = new List<int>();
            for (int i = 0; i < v.Length; i++)
            {
                Orak.Add(int.Parse(v[i]));
            }
        }

        public override string ToString()
        {
            return $"{this.Napok}. {string.Join(" ", this.Orak)}";
        }
    }
}
