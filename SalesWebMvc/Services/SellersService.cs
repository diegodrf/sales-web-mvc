using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services;

public class SellersService
{
    private readonly SalesWebMvcContext _context;

    public SellersService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public IEnumerable<Seller> FindAll() => _context.Seller.ToList();
    
    public void Insert(Seller seller)
    {
        _context.Add(seller);
        _context.SaveChanges();
    }
}