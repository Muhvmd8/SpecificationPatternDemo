namespace SpecificationPatternDemo.Specifications;
internal interface ISpecification<TEntity> 
{
    bool IsSatisfiedBy(TEntity entity); 
}
