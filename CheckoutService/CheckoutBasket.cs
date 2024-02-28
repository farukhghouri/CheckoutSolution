using CheckoutService.Model;

namespace CheckoutService
{
    public class CheckoutBasket
    {
        private readonly List<Stock> _stocks = new();
        private readonly List<SpecialPriceRule> _specialPriceRules = new();


        public void AddStock(Stock stock)
        {
            _stocks.Add(stock);
        }

        public void AddStock(params Stock[] stocks)
        {
            _stocks.AddRange(stocks);
        }

        public void AddPricingRule(SpecialPriceRule specialPriceRule)
        {
            _specialPriceRules.Add(specialPriceRule);
        }

        public int GenerateBill()
        {
            var totalBill = 0;

            foreach (var rule in _specialPriceRules)
            {
                var stocksCount = _stocks.Count(s => s.Name == rule.PricingName);

                if (stocksCount >= rule.StockCount)
                {
                    var specialPrice = stocksCount / rule.StockCount;
                    var regularPrice = stocksCount % rule.StockCount;

                    totalBill += specialPrice * rule.SpecialPriceTotal;
                    totalBill += regularPrice * rule.StockUnitPrice;
                }
                else
                {
                    totalBill += stocksCount * rule.StockUnitPrice;
                }
            }

            return totalBill;
        }
    }
}
