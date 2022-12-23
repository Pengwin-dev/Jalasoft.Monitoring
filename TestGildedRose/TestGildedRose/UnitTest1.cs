using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Text.Json.Serialization;

namespace TestGildedRose
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1_UpdateProductDecreaseQuality()
        {
            // Gouda Cheese, QV: 43, SellinValue: 16
            Product prod = new Product("Gouda Cheese",43,16);
            
            prod.UpdateProduct(); // this decreases both of the values
            Assert.AreEqual(42, prod.QualityValue);
        }

        [TestMethod]
        public void Test2_UpdateProductDecreaseSellinValue()
        {
            // Gouda Cheese, QV: 43, SellinValue: 16
            Product prod = new Product("Gouda Cheese", 43, 16);
           
            prod.UpdateProduct();
            Assert.AreEqual(15, prod.SellinValue);
        }


        [TestMethod]
        public void Test3_QualityOfItemCantBeNegative()
        {
            // Gouda Cheese, QV: 43, SellinValue: 16
            Product prod = new Product("Gouda Cheese", 0, 16);
            prod.UpdateProduct();
            // even updated the qv should remains 0
            Assert.AreEqual(0, prod.QualityValue);

        }

        [TestMethod]
        public void Test4_WhenSellinValueReachs0DecreaseQualityRateAugmentsInto2()
        {
            // Gouda Cheese, QV: 43, SellinValue: 16
            Product prod = new Product("Gouda Cheese", 2, 0);
            prod.UpdateProduct();
            // even updated the qv should remains 0
            Assert.AreEqual(0, prod.QualityValue);

        }
        [TestMethod]
        public void Test5_QualityOfItemCantBeGreaterThan50()
        {
            // Gouda Cheese, QV: 51 (gt 50), SellinValue: 2 (2daysleft)
            Product prod = new Product("Gouda Cheese", 51, 2);
            string message = string.Empty;
            // an exception should be throwed cuz QV is gt 50
            try
            {
                prod.UpdateProduct();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid Data", message);
        }
        [TestMethod]
        public void Test6_WhereNamesEqualsAgedBrieQualityIncreases()
        {
            Product prod = new Product("Aged Brie", 34, 22);
            
            prod.UpdateProduct();
            
            //the QV of Aged Brie should augment rather than decrease.
            Assert.AreEqual(35,prod.QualityValue);
        }
        [TestMethod]
        public void Test7_WhereNamesEqualsSulfurasQualityCantDiffer80()
        {
            Product prod = new Product("Sulfuras", 79, 22);
            string message = string.Empty;
            try
            {
                prod.UpdateProduct();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //an Exception should be catched for trying to get a Sulfuras with != 80 QV
            Assert.AreEqual("Invalid Data", message);
        }

        [TestMethod]
        public void Test8_WhereNamesEqualsSulfurasCantLoseQuality()
        {
            Product prod = new Product("Sulfuras", 80, 22);

            prod.UpdateProduct();

            //the QV of Sulfuras should remain
            Assert.AreEqual(80, prod.QualityValue);
        }
        [TestMethod]
        public void Test9_WhereNamesEqualsSulfurasCantBeSold()
        {
            Product prod = new Product("Sulfuras", 80, 22);

            prod.UpdateProduct();

            //the QV of Aged Brie should Increase rather than decrease.
            Assert.AreEqual(false, prod.CanBeSold);
        }
        [TestMethod]
        public void Test10_WhereNamesEqualsBackstagePassShouldIncrease2When10daysLeft()
        {
            Product prod = new Product("Backstage Pass", 34, 11);

            // BP: qv:34, days:11
            prod.UpdateProduct();
            //// BP: qv:36, days:10
            prod.UpdateProduct();
            //// BP: qv:38, days:9
            prod.UpdateProduct();
            // BP: qv:40, days:8

            //the QV of BackstagePass should Increase per day by 2 when 10 days left
            Assert.AreEqual(40,prod.QualityValue);
        }
        [TestMethod]
        public void Test11_WhereNamesEqualsBackstagePassShouldIncrease3When5daysLeft()
        {
            Product prod = new Product("Backstage Pass", 40, 6);

            prod.UpdateProduct();
            prod.UpdateProduct();
            //the QV of BackstagePass should Increase per day by 3 (2*3 =6) when 5 days left
            
            Assert.AreEqual(46, prod.QualityValue);

            
        }
        [TestMethod]
        public void Test12_WhereBackstagePassReachSellinToZeroQualityBecomesZero()
        {
            Product prod = new Product("Backstage Pass", 46, 1);

            prod.UpdateProduct();
            
            //the QV of BackstagePass should Increase per day by 3 when 5 days left

            Assert.AreEqual(0, prod.QualityValue);


        }


        [TestMethod]
        public void Test13_WhereProductIsConjuredDecreaseTwiceAsFastWhenSellInGreaterThanZero()
        {
            Product conjuredProd = new Product("Conjured Taco", 15, 6);
            conjuredProd.IsConjured = true;
            conjuredProd.UpdateProduct();
            //the QV should be 13
            Assert.AreEqual(13, conjuredProd.QualityValue);


        }

        [TestMethod]
        public void Test14_WhereProductIsConjuredDecreaseTwiceAsFastWhenReachedZero()
        {
            Product conjuredProd = new Product("Conjured Taco", 15, 0);
            conjuredProd.IsConjured = true;
            conjuredProd.UpdateProduct();
            //the QV should be 11
            Assert.AreEqual(11, conjuredProd.QualityValue);


        }




    }
}