using CheckoutService;
using CheckoutService.Model;

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
        public void ShouldBeAbleToCalculateUnitPrice(string stockName, int stockPrice, int expectedBill)
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
    }
}