using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF_1
{
    class AmountDiscount : IDiscount
    {
        public char Termek { get; set; }
        public int DB { get; set; }

        public int Order { get { return 1; } }

        public bool Clubtagsagi { get; set; }

        public double Szorzo { get; set; }
        public int GetPrice(Dictionary<char, int> arak, ref string termekek)
        {
            int mennyi = termekek.Count(x => x == Termek);
            int akciosar = 0;
            int termekar;
            if (mennyi>=DB && arak.TryGetValue(Termek, out termekar))
            {
                akciosar = (int)Math.Round(Szorzo * mennyi* termekar);
                termekek = termekek.Replace(Termek.ToString(), "");
            }
            return akciosar;
        }
    }
}
