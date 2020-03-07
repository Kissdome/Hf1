using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HF_1
{
    public class Shop
    {
        Dictionary<char, int> product = new Dictionary<char, int>();
        List<IDiscount> discounts = new List<IDiscount>();
        Dictionary<int, int> vasarlok = new Dictionary<int, int>();
        Dictionary<string, double> kuponok = new Dictionary<string, double>();

        public void RegisterProduct(char termek, int ar)
        {
            product.Add(termek, ar);
        }

        public int GetPrice(string termekek)
        {

            int sum = 0;
            int termekar;
            int kod = -1;
            double cupon = 1;

            if (termekek.Any(x => char.IsDigit(x)))
            {
                if (termekek.Contains("v"))
                {
                    var match = Regex.Matches(termekek, @"v\d+");
                    var codeswithv = match.Select(x => x.Value).FirstOrDefault();
                    kod = int.Parse(codeswithv.Substring(1, codeswithv.Length-1));
                    if (!vasarlok.ContainsKey(kod))
                    {
                        vasarlok.Add(kod, 0);
                    }
                    termekek = termekek.Replace(codeswithv, "");
                }
                if (termekek.Contains("k"))
                {
                    var match = Regex.Matches(termekek, @"k\d+");
                    var codeswithk = match.Select(x => x.Value).FirstOrDefault();
                    string cuponcode = codeswithk.Substring(1, codeswithk.Length-1);

                    //ide jön a cucc
                    if (kuponok.ContainsKey(cuponcode))
                    {
                        cupon = kuponok[cuponcode];
                        kuponok.Remove(cuponcode);
                    }
                    termekek = termekek.Replace(codeswithk, "");

                }
            }
            bool clubtag_e = kod > -1;

            if (!clubtag_e)
                sum = discounts.Where(x => !x.Clubtagsagi).OrderBy(x =>x.Order).Sum(x => x.GetPrice(product, ref termekek));
            else
                sum = discounts.OrderBy(x=>x.Order).Sum(x => x.GetPrice(product, ref termekek));

            //foreach (var item in discounts)
            //{
            //    sum += item.GetPrice(product,ref termekek);
            //}

            foreach (var item in termekek)
            {
                if (product.TryGetValue(item, out termekar))
                {
                    sum += termekar;
                }
            }

            sum = (int)(sum * cupon);



            if (kod > -1) //klubtag
            {
                sum = (int)(sum * 0.9);

                if (termekek.Contains("p"))
                {
                    sum -= vasarlok[kod];
                    if (sum <= 0)
                    {
                        vasarlok[kod] = -sum;
                        sum = 0;
                    }
                    else
                    { vasarlok[kod] = 0; }
                }
                else { vasarlok[kod] = (int)Math.Round(sum * 0.01); }
            }
            return sum;
        }
        public void RegisterCountDiscount(char nev, int a, int b, bool combo = false)
        {
            discounts.Add(new CountDiscount() { Termek = nev, Mennyit = b, Mennyiert = a, Clubtagsagi = combo });
        }

        public void RegisterAmountDiscount(char v1, int v2, double v3, bool combo = false)
        {
            discounts.Add(new AmountDiscount() { Termek = v1, DB = v2, Szorzo = v3, Clubtagsagi = combo });
        }

        public void RegisterComboDiscount(string akcio, int uj, bool combo = false)
        {
            discounts.Add(new ComboDiscount() { Termekek = akcio, Ujar = uj, Clubtagsagi = combo });
        }

        public void RegisterCoupon(string kupon, double akcio)
        {
            if (!kuponok.ContainsKey(kupon))
            {
                kuponok.Add(kupon, akcio);
            }

        }
    }
}
