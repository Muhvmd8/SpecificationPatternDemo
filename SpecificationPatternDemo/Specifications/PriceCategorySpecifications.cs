namespace SpecificationPatternDemo.Specifications;
internal class PriceCategorySpecifications<T> : ISpecification<T>
{
    private readonly ISpecification<T> _first;
    private readonly ISpecification<T> _second;

    public PriceCategorySpecifications(ISpecification<T> first, ISpecification<T> second)
    {
        _first = first;
        _second = second;
    }
    public bool IsSatisfiedBy(T item) => _first.IsSatisfiedBy(item) && _second.IsSatisfiedBy(item);
}
