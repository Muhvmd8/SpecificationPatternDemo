# Specification Pattern Demo

A demonstration of how to use the **Specification Pattern** in C# to write cleaner, more maintainable, and testable business rules — avoiding messy chains of `if-else` conditions.

---

## 📌 Introduction

The Specification Pattern is a design pattern that allows you to encapsulate business rules into reusable, combinable objects.  
Instead of writing complex conditional statements all over your code, you define "specifications" and combine them using logic operators (`==`, `<`, `&&`).

This makes your code:
- Easier to **read**
- Easier to **maintain**
- Easier to **test**
- Adhering to **SOLID Principles** (especially the Open/Closed principle)

---

## 🎯 Example Use Case

In this demo, we have a `Product` entity with attributes like:
- Name
- Price
- Category

We want to filter products based on various criteria without writing big `if-else` blocks.

Example:
- Products that are **in Electronics category** AND **cost less than 100**

---

## 🏗 Project Structure

```
SpecificationPatternDemo/
│
├── Models/
│   └── Product.cs
│
├── Specifications/
│   ├── ISpecification.cs
│   ├── PriceSpecification.cs
│   ├── CategorySpecification.cs
│   ├── PriceCategorySpecifications.cs
│   ├── PriceSpecification.cs
│   ├── CategorySpecification.cs
│   └── InStockSpecification.cs
|
├── Repositories/
│   ├── ProductRespository.cs       
│
├── Program.cs
└── README.md
```

---

## 📂 How It Works

### 1️⃣ The `ISpecification` Interface
Defines the contract for all specifications:
```csharp
internal interface ISpecification<TEntity> 
{
    bool IsSatisfiedBy(TEntity entity); 
}
```

### 2️⃣ Concrete Specifications
Example: PriceSpecification
```csharp
internal class PriceSpecification : ISpecification<Product>
{
    private readonly decimal _maxPrice;
    public PriceSpecification(decimal maxPrice)
    {
        _maxPrice = maxPrice;
    }
    public bool IsSatisfiedBy(Product entity) => entity.Price <= _maxPrice;
}
```

### 3️⃣ Composing Specifications
```csharp
var electronicsSpec = new CategorySpecification("Clothing");
var cheapSpec = new PriceSpecification(100);
var cheapElectronicsSpec = new PriceCategorySpecifications<Product>(electronicsSpec, cheapSpec);

Console.WriteLine("Cheap Electronics:");

foreach (var product in repo.GetProducts(cheapElectronicsSpec))
    Console.WriteLine(product);
```

---

## 🚀 How to Run

1. Clone the repository:
```bash
git clone https://github.com/Muhvmd8/SpecificationPatternDemo.git
cd SpecificationPatternDemo
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run
```

---

## 💡 Why Use This Pattern?

- Reduces `if-else` clutter
- Keeps business rules in one place
- Makes it easy to extend without modifying existing code (OCP)
- Improves testability of business logic

