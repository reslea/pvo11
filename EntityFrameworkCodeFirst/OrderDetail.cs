using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderDetail
{
    public int OrderId { get; set; }

    public Order Order { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public decimal Discount { get; set; }
}

public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(_ => new { _.OrderId, _.ProductId });

        builder.HasData(new OrderDetail { ProductId = 1, OrderId = 1, Price = 99, Quantity = 1 });
        builder.HasData(new OrderDetail { ProductId = 2, OrderId = 1, Price = 5, Quantity = 1, Discount = 0.05m });
        builder.HasData(new OrderDetail { ProductId = 3, OrderId = 1, Price = 22, Quantity = 1, Discount = 0.10m });

    }
}
