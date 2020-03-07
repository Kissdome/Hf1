using HF_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testst
{
    [TestClass]
    public class UnitTest1
    
        {
            Shop Shop = new Shop();
            [TestMethod]
            public void Feladat1()
            {
                Shop.RegisterProduct('A', 10);
                Shop.RegisterProduct('C', 20);
                Shop.RegisterProduct('E', 50);
                Assert.AreEqual(Shop.GetPrice("ACEE"), 130);  // 130-at ad vissza

            }

            [TestMethod]
            public void Feladat2()
            {
                Shop.RegisterProduct('A', 10);
                Shop.RegisterProduct('E', 50);
                Shop.RegisterCountDiscount('A', 3, 4);
                Assert.AreEqual(Shop.GetPrice("AAAAAEEE"), 190);  // 5*10+3*50 helyett 4*10+3*50
            }
            [TestMethod]
            public void Feladat3()
            {
                Shop.RegisterProduct('A', 10);
                Shop.RegisterProduct('B', 100);
                Shop.RegisterAmountDiscount('A', 5, 0.9);   // 5 darabtól, 0.9-es szorzó
                Assert.AreEqual(Shop.GetPrice("AAAAAAB"), 154);  // 6*10*0.9+100
            }

            [TestMethod]
            public void Feladat4()
            {
                Shop.RegisterProduct('A', 10);
                Shop.RegisterProduct('B', 20);
                Shop.RegisterProduct('C', 50);
                Shop.RegisterProduct('D', 100);
                Shop.RegisterComboDiscount("ABC", 60);
                Assert.AreEqual(Shop.GetPrice("CAAAABB"), 110);
            }
            [TestMethod]
            public void Feladat5()
            {
                Shop.RegisterProduct('A', 10);
                Shop.RegisterProduct('B', 20);
                Shop.RegisterProduct('C', 50);
                Shop.RegisterProduct('D', 100);
                Shop.RegisterComboDiscount("ABC", 60);
                Assert.AreEqual(Shop.GetPrice("CAAAABBv123"), 99);
            }

            [TestMethod]
            public void Feladat6()
            {
                Shop.RegisterProduct('A', 10);
                Shop.RegisterProduct('B', 20);
                Shop.RegisterProduct('C', 50);
                Shop.RegisterProduct('D', 100);
                Shop.RegisterComboDiscount("ABC", 60, true);
                Assert.AreEqual(Shop.GetPrice("CAAAABB"), 130);
            }

            [TestMethod]
            public void Feladat7()
            {
                Shop.RegisterProduct('A', 10);
                Shop.RegisterProduct('B', 100);
                Shop.RegisterAmountDiscount('A', 5, 0.9);   // 5 darabtól, 0.9-es szorzó
                Shop.GetPrice("AAAAAAB3");


                Assert.AreEqual(Shop.GetPrice("AAAAAAB3p"), 154);

            }

            [TestMethod]
            private void Feladat8()
            {
                Shop.RegisterProduct('A', 10);
                Shop.RegisterProduct('B', 100);
                Shop.RegisterAmountDiscount('B', 5, 0.9);
                Shop.RegisterCountDiscount('A', 3, 4);
                Shop.GetPrice("AAAAAABBBBB");  

                Assert.AreEqual(Shop.GetPrice("AAAAAABBBBB"), 500);

            }
        [TestMethod]
        public void Cupons()
        {
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 20);
            Shop.RegisterCoupon("112554", 0.9); // -10% kupon
            var price1 = Shop.GetPrice("AABk112554");  // 40*0.9
            var price2 = Shop.GetPrice("AABk112554");

            Assert.AreNotEqual(price1, price2);

        }



    }
    }
