using Microsoft.EntityFrameworkCore;
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

    public Seller? FindById(int id)
    {
        return _context.Seller
            .Include(e => e.Department)
            .AsNoTracking()
            .FirstOrDefault(e => e.Id == id);
    }

    public void Remove(int id)
    {
        var seller = FindById(id);
            
        if (seller is null) return;
            
        _context.Seller.Remove(seller);
        _context.SaveChanges();
    }
}