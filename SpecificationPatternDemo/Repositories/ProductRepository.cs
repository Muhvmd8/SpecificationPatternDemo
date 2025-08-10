namespace SpecificationPatternDemo.Repositories;
internal class ProductRepository
{
    private readonly List<Product> _products;
    public ProductRepository(List<Product> products)
    {
        _products = products;
    }

    // Search for product by the conditions and rules that is applyed in the speceification implementaion.
    public IEnumerable<Product> GetProducts(ISpecification<Product> specification) // Take specs
        => _products.Where(p => specification.IsSatisfiedBy(p));
}

