using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services;

public class SellersService
{
    private readonly SalesWebMvcContext _context;

    public SellersService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public IEnumerable<Seller> FindAll()
    {
        return _context.Seller
        .AsNoTracking()
        .ToList();
    }

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

    public void Update(Seller seller)
    {   
        if (!_context.Seller.Any(e => e.Id == seller.Id))
        {
            throw new NotFoundException($"Seller Id [{seller.Id}] not found.");
        }

        try
        {
            _context.Update(seller);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new DbConcurrencyException(e.Message);
        }
        catch (DbUpdateException e)
        {
            throw new DbConcurrencyException(e.Message);
        } 
    }
}