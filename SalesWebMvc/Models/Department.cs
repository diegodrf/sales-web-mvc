namespace SalesWebMvc.Models;

public class Department
{
    public int Id { get; set; } = new Random().Next(1, int.MaxValue);
    public string Name { get; set; } = string.Empty;
}