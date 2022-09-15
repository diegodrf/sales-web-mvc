using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services;

public class DepartmentsService
{
    private readonly SalesWebMvcContext _context;

    public DepartmentsService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public IList<Department> FindAll() 
        => _context
        .Department
        .OrderBy(e => e.Name)
        .ToList();
    
}