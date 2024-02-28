namespace CheckoutService.Model
{
    public class SpecialPriceRule
    {
        public string PricingName { get; set; }
        public int StockCount { get; set; }
        public int StockUnitPrice { get; set; }
        public int SpecialPriceTotal { get; set; }
    }
}
