using HomeTask3.DatabaseContext;
using HomeTask3.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeTask3.UnitOfWork.Concrete;

public class UnitOfWork
{
    private readonly AppDbContext _context;

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProgramInitializerService> ProgramInitializerServices { get; set; }

    public UnitOfWork()
    {
        _context = new AppDbContext();
        Contacts = _context.Contacts;
        Customers = _context.Customers;
        Orders = _context.Orders;
        Products = _context.Products;
        ProductCategories = _context.ProductCategories;
        ProgramInitializerServices = _context.ProgramInitializerServices;
    }

    #region CRUD

    #region Product
    public void AddProduct(Product product)
    {
        Products.Add(product);
        Save();
        Console.WriteLine("New Product Added");
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(Products.Find(product.Id));
        Save();
        Console.WriteLine("Product Removed");
    }

    public void UpdateProduct(Product product)
    {
        var data = Products.Find(product.Id);
        data.Quantity = product.Quantity;
        Save();
        Console.WriteLine("Product Updated");
    }
    #endregion

    #region Customer
    public void AddCustomer(Customer customer)
    {
        Customers.Add(customer);
        Save();
        Console.WriteLine("New Customer Added");
    }

    public void RemoveCustomer(Customer customer)
    {
        Customers.Remove(Customers.Find(customer));
        Save();
        Console.WriteLine("Customer Removed");
    }

    #endregion

    #region Order
    public void AddOrder(Order order)
    {
        Orders.Add(order);
        Products.FirstOrDefault(p => p.Id == order.ProductId).Quantity -= order.Quantity;
        Save();
        Console.WriteLine("New Order Added");
    }
    #endregion

    public void RemoveContact(Contact contact)
    {
        Contacts.Remove(Contacts.Find(contact.Id));
        Save();
        Console.WriteLine("Contact Removed");
    }

    public void AddCategory(ProductCategory category)
    {
        ProductCategories.Add(category);
        Save();
        Console.WriteLine("New Category Added");
    }

    public void Save() { _context.SaveChanges(); }
    #endregion

    #region Show
    public void ShowAllCategories()
    {
        foreach (var item in _context.ProductCategories)
        {
            item.Show();
        }
    }

    public void ShowAllProducts()
    {
        int row = 1;

        foreach (var item in Products)
        {
            item.Show(row++, GetProductCategoryById(item.ProductCategoryId).Category);
        }
    }

    public void ShowAllProducts2()
    {
        foreach (var item in Products)
        {
            item.Show();
        }
    }

    public void ShowProductsByCategories()
    {
        int row;

        foreach (var pc in ProductCategories)
        {
            row = 1;
            pc.Show2();
            foreach (var p in GetProductsByProductCategoryId(pc.Id))
            {
                p.Show(row++);
            }
        }
    }

    public void ShowAllCustomers()
    {
        int row = 1;

        foreach (var item in Customers)
        {
            item.Show(row++, GetContactById(item.ContactId));
        }
    }

    public void ShowAllTransactions()
    {
        int row = 1;
        foreach (var item in Orders)
        {
            item.Show(row++);
        }
    }
    #endregion

    #region Calculations
    public void TotalCustomerCount()
    {
        Console.Clear();
        Console.Write($"Total customer count: {Customers.Count()}\n\n");
    }

    public void TotalProductCount()
    {
        Console.Clear();
        Console.Write($"Total product count: {Products.Count()}\n\n");
    }

    public void TotalQuantitySold()
    {
        decimal total = 0;
        Orders.ToList().ForEach(q => total += q.Quantity);
        Console.WriteLine($"Total quantity sold: {total}\n\n");
    }

    public void TotalRevenue()
    {
        decimal total = Orders.Sum(order => order.Quantity * order.Product.SalesPrice);
        Console.WriteLine($"Total revenue: {total}\n\n");
    }

    #endregion

    #region Methods
    public ProductCategory GetProductCategoryById(int id)
    {
        var context = new AppDbContext();
        return context.ProductCategories.FirstOrDefault(pc => pc.Id == id);
    }

    public ICollection<Product> GetProductsByProductCategoryId(int pcid)
    {
        var context = new AppDbContext();
        return context.Products.Where(p => p.ProductCategoryId == pcid).ToList();
    }

    public Contact GetContactById(int contactId)
    {
        var context = new AppDbContext();
        return context.Contacts.FirstOrDefault(c => c.Id == contactId);
    }

    public Product GetProductById(int id)
    {
        var context = new AppDbContext();
        return context.Products.FirstOrDefault(p => p.Id == id);
    }

    #endregion

}
