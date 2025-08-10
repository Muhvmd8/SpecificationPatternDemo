namespace SpecificationPatternDemo.Specifications;
internal class PriceSpecification : ISpecification<Product>
{
    private readonly decimal _maxPrice;
    public PriceSpecification(decimal maxPrice)
    {
        _maxPrice = maxPrice;
    }
    public bool IsSatisfiedBy(Product entity) => entity.Price <= _maxPrice;
}
