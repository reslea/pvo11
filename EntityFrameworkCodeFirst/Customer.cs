using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime RegisterDate { get; set; }

    public List<Order> Orders { get; set; }
}

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(new Customer { Id = 1, Name = "John Doe" });
    }
}