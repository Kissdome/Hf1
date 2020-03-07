using System;
using System.Collections.Generic;
using System.Text;

namespace HF_1
{
    interface IDiscount
    {
        int Order { get; }
        bool Clubtagsagi { get;}
        int GetPrice(Dictionary<char, int> arak, ref string termekek);
    }
}
