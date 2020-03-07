using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF_1
{
    class ComboDiscount : IDiscount
    {
        public string Termekek { get; set; }
        public int Ujar { get; set; }
        public bool Clubtagsagi { get; set; }

        public int Order { get { return 3; } }
        public int GetPrice(Dictionary<char, int> arak, ref string termekek)
        {
            Dictionary<char, int> akcios = CountString(Termekek);

            Dictionary<char, int> products = CountString(termekek);
            Dictionary<char, int> temp = products.ToDictionary(entry => entry.Key,
                                                               entry => entry.Value);



            bool bennevan = true;
            int hanyszor = 0;

            while (bennevan)
            {
                foreach (var item in akcios)
                {
                    int db = 0;
                    if (temp.TryGetValue(item.Key, out db) && db >= item.Value)
                    {
                        temp[item.Key] = db - item.Value;
                    }
                    else { bennevan = false; break; }
                }
                if (bennevan)
                {
                    hanyszor++;
                    products = temp.ToDictionary(entry => entry.Key,
                                                           entry => entry.Value);
                }
               

            }
            termekek = string.Join("", products.Select(x => string.Join("", Enumerable.Repeat(x.Key, x.Value))));
            return hanyszor * Ujar;
        }

        private Dictionary<char, int> CountString(string szoveg)
        {
            return szoveg.GroupBy(c => c).ToDictionary(x => x.Key, x => x.Count());
        }
    }
}
