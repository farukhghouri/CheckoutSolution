using CheckoutService;
using CheckoutService.Model;

namespace CheckoutKataTests
{
    [TestClass]
    public class CheckoutPricingTests
    {
        [TestMethod]
        public void ShouldBeAbleToCalculateUnitPrice()
        {
            //arrange
            var checkout = new CheckoutBasket();

            var stock = new Stock() { Name = "A", Price = 50 };
            checkout.AddStock(stock);

            var expectedBill = 50;
            //act
            var bill = checkout.GenerateBill();

            //assert
            Assert.AreEqual(expectedBill, bill, "Incorrect unit price calculated");
        }
    }
}