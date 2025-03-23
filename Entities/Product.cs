namespace HomeTask3.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int ProductCategoryId { get; set; }
    public int Quantity { get; set; }
    public decimal SalesPrice { get; set; }

    public ProductCategory ProductCategory { get; set; }
    public ICollection<Order> Orders { get; set; }

    public void Show(int row, string categoryName)
    {
        Console.WriteLine(
            $"{row}. product\n" +
            $"Product name: {ProductName}\n" +
            $"Product category: {categoryName}\n" +
            $"Quantity: {Quantity}\n" +
            $"Sales price: {SalesPrice}\n"
            );
    }

    public void Show(int row)
    {
        Console.WriteLine(
            $"{row}. product\n" +
            $"ID. {Id}\n" +
            $"Product name: {ProductName}\n" +
            $"Quantity: {Quantity}\n" +
            $"Sales price: {SalesPrice}\n"
            );
    }

    public void Show()
    {
        Console.WriteLine(
            $"ID. {Id}\n" +
            $"Product name: {ProductName}\n" +
            $"Quantity: {Quantity}\n" +
            $"Sales price: {SalesPrice}\n"
            );
    }
}
