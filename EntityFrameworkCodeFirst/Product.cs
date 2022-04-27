using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(new Product { Id = 1, Name = "Книга", Price = 100 });
        builder.HasData(new Product { Id = 2, Name = "Набор закладок", Price = 5 });
        builder.HasData(new Product { Id = 3, Name = "Блокнот", Price = 20 });
    }
}