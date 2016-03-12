using Market.Core.Products;

namespace Market.Core.Infrastructure
{
    public abstract class MarketError
    {
        public ErrorType ErrorType { get; set; }
    }
}