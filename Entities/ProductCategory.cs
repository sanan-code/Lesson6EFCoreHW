namespace HomeTask3.Entities;

public class ProductCategory
{
    public int Id { get; set; }
    public string Category { get; set; }
    public ICollection<Product> Products { get; set; }

    public void Show()
    {
        Console.WriteLine($"{Id}. {Category}");
    }

    public void Show2()
    {
        Console.WriteLine($"{Category} --------------------------------------- ");
    }

}
