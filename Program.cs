using System;

namespace HF_1
{
    class Program
    {
        static Shop Shop = new Shop();
        static void Main(string[] args)
        {
            Console.WriteLine(Feladat3());
            Console.ReadKey();
            Console.WriteLine("Hello World");
        }

        private static int Feladat1()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('C', 20);
            Shop.RegisterProduct('E', 50);
            return Shop.GetPrice("ACEE");
        }
        private static int Feladat2()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('E', 50);
            Shop.RegisterCountDiscount('A', 3, 4); // 3 áráért 4-et vihet
            return Shop.GetPrice("AAAAAEEE");  // 5*10+3*50 helyett 4*10+3*50
        }
        private static int Feladat3()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 100);
            Shop.RegisterAmountDiscount('B', 5, 0.9);
            Shop.RegisterCountDiscount('A', 3, 4);// 5 darabtól, 0.9-es szorzó
            return Shop.GetPrice("AAAAAABBBBB");  // 6*10*0.9+100

        }

        private static int Feladat4()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 20);
            Shop.RegisterProduct('C', 50);
            Shop.RegisterProduct('D', 100);
            Shop.RegisterComboDiscount("ABC", 60);
            return Shop.GetPrice("CAAAABB");  // ABC+AAAB -> 60+3*10+20

        }
        private static int Feladat5()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 20);
            Shop.RegisterProduct('C', 50);
            Shop.RegisterProduct('D', 100);
            Shop.RegisterComboDiscount("ABC", 60);
            return Shop.GetPrice("CAAAABBt");  // ABC+AAAB -> 60
        }

        private static int Feladat6()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 20);
            Shop.RegisterProduct('C', 50);
            Shop.RegisterProduct('D', 100);
            Shop.RegisterComboDiscount("ABC", 60,true);
            return Shop.GetPrice("CAAAABB");  

        }

        private static int Feladat7()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 100);
            Shop.RegisterAmountDiscount('A', 5, 0.9);   // 5 darabtól, 0.9-es szorzó
            Shop.GetPrice("AAAAAAB3");

 
            return Shop.GetPrice("AAAAAAB3p");
        }

        private static int Kuponok()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 20);
            Shop.RegisterCoupon("112554", 0.9); // -10% kupon
            Shop.GetPrice("AABk112554");
            return  Shop.GetPrice("AABk112554");  // 40*0.9
            //var price2 = Shop.GetPrice("AABk112554");  // 40, mert már elhasználták a kupont

        }
       
    }
}
