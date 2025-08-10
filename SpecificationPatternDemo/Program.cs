namespace SpecificationPatternDemo;
internal class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>()
        {
            new Product("Laptop", "Electronics", 1200),
            new Product("Phone", "Electronics", 800),
            new Product("Shirt", "Clothing", 50),
            new Product("Jeans", "Clothing", 70),
            new Product("iPad", "Electronics", 1000)
        };

        var repo = new ProductRepository(products);

        var electronicsSpec = new CategorySpecification("Clothing");
        var cheapSpec = new PriceSpecification(100);
        var cheapElectronicsSpec = new PriceCategorySpecifications<Product>(electronicsSpec, cheapSpec);

        Console.WriteLine("Cheap Electronics:");

        foreach (var product in repo.GetProducts(cheapElectronicsSpec))
            Console.WriteLine(product);
    }
}
