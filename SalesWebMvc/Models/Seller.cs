using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models;

public class Seller
{
    public int Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
    public double BaseSalary { get; init; }
    public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
    public Department Department { get; set; }

    public int DepartmentId {  get; set; }

    public Seller()
    {
        
    }

    public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddSales(SalesRecord salesRecord)
    {
        Sales.Add(salesRecord);
    }

    public void RemoveSales(SalesRecord salesRecord)
    {
        Sales.Remove(salesRecord);
    }

    public double TotalSales(DateTime initial, DateTime final)
    {
        return (
            from sale in Sales
            where sale.Date >= initial && sale.Date <= final
            select sale.Amount
            ).Sum();
    }
}