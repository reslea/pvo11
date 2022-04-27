using Microsoft.EntityFrameworkCore;

using var context = new StoreContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var getOrder = context.Orders
    .Include(o => o.Shipment)
    .Include(o => o.OrderDetails)
    .ThenInclude(od => od.Product)
    .FirstOrDefault();

Console.WriteLine($"order: {getOrder.Id}, shipment: {getOrder.Shipment.Name}");
Console.WriteLine("products: ");
foreach (var orderDetail in getOrder.OrderDetails)
{
    Console.WriteLine($"{orderDetail.Product.Name} x {orderDetail.Quantity}");
}