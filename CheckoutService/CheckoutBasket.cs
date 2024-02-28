using CheckoutService.Model;

namespace CheckoutService
{
    public class CheckoutBasket
    {
        private readonly List<Stock> _stocks = new();


        public void AddStock(Stock stock)
        {
            _stocks.Add(stock);
        }

        public int GenerateBill()
        {
            return _stocks.GroupBy(s=> s.Name)
                .Select(i=> i.Sum(i=> i.Price))
                .Sum();
        }
    }
}
