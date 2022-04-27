using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Shipment
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Order> Orders { get; set; }
}

public class ShipmentConfig : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasData(new Shipment { Id = 1, Name = "Nova Poshta" });
        builder.HasData(new Shipment { Id = 2, Name = "Ukrposhta" });
    }
}
