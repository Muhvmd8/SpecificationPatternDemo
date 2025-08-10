namespace SpecificationPatternDemo.Specifications;
internal class CategorySpecification : ISpecification<Product>
{
    private readonly string _category;
    public CategorySpecification(string category) 
    {
        _category = category;
    }
    public bool IsSatisfiedBy(Product entity) 
        => entity.Category.ToLower() == _category.ToLower();
}
