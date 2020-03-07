using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF_1
{
    public class CountDiscount : IDiscount
    {
        public char Termek { get; set; }
        public int Mennyit { get; set; }
        public int Mennyiert { get; set; }
        public bool Clubtagsagi { get; set; }

        public int Order { get { return 0; } }

        public int GetPrice(Dictionary<char, int> arak, ref string termekek)
        {
            int db = termekek.Count(x => x == Termek);
            int akcios = db / Mennyit;
            int nemakcios = db % Mennyit;
            int realdb = akcios * Mennyiert;
            int akciosar = 0;
            int termekar;
            if (arak.TryGetValue(Termek, out termekar))
            {
                akciosar = realdb * termekar;
                termekek = termekek.Replace(Termek.ToString(), "") + string.Join("", Enumerable.Repeat(Termek, nemakcios));
            }
            return akciosar;
        }
    }
}
