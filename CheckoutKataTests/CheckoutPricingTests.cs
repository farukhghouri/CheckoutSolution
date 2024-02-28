using CheckoutService;
using CheckoutService.Model;
using System.Security.Cryptography.X509Certificates;

namespace CheckoutKataTests
{
    [TestClass]
    public class CheckoutPricingTests
    {
        private CheckoutBasket checkout = new();

        [TestInitialize]
        public void Setup()
        {
            var pricingRuleForA = new SpecialPriceRule { PricingName = "A", StockCount = 3, StockUnitPrice = 50, SpecialPriceTotal = 130 };
            var pricingRuleForB = new SpecialPriceRule { PricingName = "B", StockCount = 2, StockUnitPrice = 30, SpecialPriceTotal = 45 };

            checkout.AddPricingRule(pricingRuleForA);
            checkout.AddPricingRule(pricingRuleForB);
        }

        [DataTestMethod]
        [DataRow("A", 50, 50)]
        [DataRow("B", 30, 30)]
        public void ShouldBeAbleToCalculateSingleUnitPrice(string stockName, int stockPrice, int expectedBill)
        {
            //arrange
            var stock = new Stock() { Name = stockName, Price = stockPrice };
            checkout.AddStock(stock);

            //act
            var bill = checkout.GenerateBill();

            //assert
            Assert.AreEqual(expectedBill, bill, "Incorrect unit price calculated");
        }

        [TestMethod]
        public void ShouldBeAbleToCalculateMultipleUnitPrice()
        {
            //arrange
            var stock = new Stock() { Name = "A", Price = 50 };
            var anotherStock = new Stock() { Name = "B", Price = 30 };

            var expectedBill = stock.Price + anotherStock.Price;

            checkout.AddStock(stock, anotherStock);

            //act
            var bill = checkout.GenerateBill();

            //assert
            Assert.AreEqual(expectedBill, bill, "Incorrect multiple unit price calculated");
        }

        [TestMethod]
        public void ShouldBeAbleToAddSinglePircingRule()
        {
            //arrange
            var stock = new Stock() { Name = "A", Price = 50 };

            var expectedBill = 130;
            
            checkout.AddStock(stock, stock, stock);

            //act
            var bill = checkout.GenerateBill();

            //assert
            Assert.AreEqual(expectedBill, bill, "Incorrect single pricing rule calculated");
        }
    }
}