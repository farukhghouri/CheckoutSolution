using CheckoutService;
using CheckoutService.Model;
using System.Security.Cryptography.X509Certificates;

namespace CheckoutKataTests
{
    [TestClass]
    public class CheckoutPricingTests
    {
        [DataTestMethod]
        [DataRow("A", 50, 50)]
        [DataRow("B", 30, 30)]
        [DataRow("C", 20, 20)]
        [DataRow("D", 15, 15)]
        public void ShouldBeAbleToCalculateSingleUnitPrice(string stockName, int stockPrice, int expectedBill)
        {
            //arrange
            var checkout = new CheckoutBasket();

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
            var checkout = new CheckoutBasket();

            var stock = new Stock() { Name = "A", Price = 50 };
            var anotherStock = new Stock() { Name = "B", Price = 30 };

            var expectedBill = stock.Price + anotherStock.Price;

            checkout.AddStock(stock);
            checkout.AddStock(anotherStock);

            //act
            var bill = checkout.GenerateBill();

            //assert
            Assert.AreEqual(expectedBill, bill, "Incorrect multiple unit price calculated");
        }

    }
}