using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class OrderService : IOrderService
{
    private ApplicationDbContext _context;
    
    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<Order> GetOrder()
    {
        return Task.FromResult(_context.Orders.OrderByDescending(o => o.Price).FirstOrDefault());
    }

    public Task<List<Order>> GetOrders()
    {
        return Task.FromResult(_context.Orders.Where(o => o.Quantity > 10).ToList());
    }
}