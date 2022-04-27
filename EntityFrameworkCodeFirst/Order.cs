using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    public int ShipVia { get; set; }

    public Shipment Shipment { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(o => o.Shipment)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.ShipVia);

        builder.HasData(new Order { Id = 1, CustomerId = 1, ShipVia = 1 });
    }
}
