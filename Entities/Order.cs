using HomeTask3.DatabaseContext;

namespace HomeTask3.Entities;

public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerID { get; set; }
    public DateOnly SalesDate { get; set; }
    public int Quantity { get; set; }

    public Product Product { get; set; }
    public Customer Customer { get; set; }

    public void Show(int row)
    {
        Console.WriteLine($"{row}. ");
        Console.WriteLine(
            $"Id: {Id}\n" +
            $"Product: {GetProductNameById()}\n" +
            $"Customer: {GetCustomerNameById()}\n" +
            $"Sales date: {SalesDate.ToString("dd.MM.yyyy")}\n" +
            $"Quantity: {Quantity}\n"
            );
    }

    private string GetProductNameById()
    {
        var context = new AppDbContext();
        return context.Products.FirstOrDefault(p => p.Id == ProductId).ProductName;
    }

    private string GetCustomerNameById()
    {
        var context = new AppDbContext();
        var customer = context.Customers.FirstOrDefault(c => c.Id == CustomerID);
        return $"{customer.Name} {customer.Surname}";
    }
}


