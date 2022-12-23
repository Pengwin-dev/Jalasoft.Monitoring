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
    }
}