namespace HomeTask3.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int ContactId { get; set; }

    public Contact Contact { get; set; }
    public ICollection<Order> Orders { get; set; }

    public void Show(int row, Contact contact)
    {
        Console.WriteLine($"{row}. customer");
        Console.WriteLine(
            $"Id: {Id}\n" +
            $"Name: {Name}\n" +
            $"Surname: {Surname}\n" +
            $"Phone: {contact.Phone}\n" +
            $"Email: {contact.Email}\n"
            );
    }
}
