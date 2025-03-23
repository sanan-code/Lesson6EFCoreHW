using HomeTask3.Common;
using HomeTask3.Entities;

namespace HomeTask3.BusinessContext;

public class BusinessProcess
{
    private readonly CommonBehaviours _commonBehaviour;
    private readonly UnitOfWork.Concrete.UnitOfWork _unitOfWork;

    bool program = true;
    bool reporting = true;
    private int menu1select = 0;

    public BusinessProcess()
    {
        _unitOfWork = new UnitOfWork.Concrete.UnitOfWork();
        _commonBehaviour = new CommonBehaviours();
    }

    public void Start()
    {
        Console.WriteLine("\tSales Program\n");
        _commonBehaviour.Sleep(3, 500);
        Console.Clear();

        while (program)
        {
            Menu.menu1();
            menu1select = _commonBehaviour.Select();
            Console.Clear();

            switch (menu1select)
            {
                case 1:
                    AddProductProcess();
                    _commonBehaviour.Sleep(5, 500);
                    Console.Clear();
                    break;
                case 2:
                    RemoveProductProcess();
                    _commonBehaviour.Sleep(5, 500);
                    Console.Clear();
                    break;
                case 3:
                    UpdateProductProcess();
                    _commonBehaviour.Sleep(5, 500);
                    Console.Clear();
                    break;
                case 4:
                    AddCustomerProcess();
                    _commonBehaviour.Sleep(5, 500);
                    Console.Clear();
                    break;
                case 5:
                    RemoveCustomerProcess();
                    _commonBehaviour.Sleep(5, 500);
                    Console.Clear();
                    break;
                case 6:
                    AddOrderProcess();
                    _commonBehaviour.Sleep(5, 500);
                    Console.Clear();
                    break;
                case 7:
                    reporting = true;
                    while (reporting)
                        reporting = ReportingProcess();
                    break;
                default:
                    program = false;
                    Console.Write("Exiting the system");
                    _commonBehaviour.Sleep(3, 500);
                    break;
            }

        }
    }

    public void InitProgram()
    {
        //eger init olunubsa artiq yeniden etmeye ehtiyac yoxdur
        if (_unitOfWork.ProgramInitializerServices.FirstOrDefault(p => p.Service == "InitProgram Datas" && p.Value == "yes") != null) return;

        //Product Categories
        var pc1 = new ProductCategory() { Category = "Food" };
        var pc2 = new ProductCategory() { Category = "Drink" };
        var pc3 = new ProductCategory() { Category = "Entertainment" };
        var pc4 = new ProductCategory() { Category = "Home" };

        var categories = new List<ProductCategory>() { pc1, pc2, pc3, pc4 };

        //Product
        var product1 = new Product() { ProductName = "Bread", ProductCategory = pc1, Quantity = 10, SalesPrice = 0.70m };
        var product2 = new Product() { ProductName = "Cake", ProductCategory = pc1, Quantity = 15, SalesPrice = 5m };
        var product3 = new Product() { ProductName = "Water", ProductCategory = pc2, Quantity = 20, SalesPrice = 0.50m };
        var product4 = new Product() { ProductName = "Sirab", ProductCategory = pc2, Quantity = 15, SalesPrice = 1m };
        var product5 = new Product() { ProductName = "Istisu", ProductCategory = pc2, Quantity = 50, SalesPrice = 1.5m };
        var product6 = new Product() { ProductName = "RC Car", ProductCategory = pc3, Quantity = 5, SalesPrice = 25m };
        var product7 = new Product() { ProductName = "Doll", ProductCategory = pc3, Quantity = 10, SalesPrice = 10m };
        var product8 = new Product() { ProductName = "Table", ProductCategory = pc4, Quantity = 10, SalesPrice = 15m };
        var product9 = new Product() { ProductName = "Towel", ProductCategory = pc4, Quantity = 20, SalesPrice = 7m };

        var products = new List<Product>() { product1, product2, product3, product4, product5, product6, product7, product8, product9 };

        //Contact
        var contact1 = new Contact() { Phone = "1234567898", Email = "cust1@mail.com" };
        var contact2 = new Contact() { Phone = "1234567899", Email = "cust2@mail.com" };
        var contact3 = new Contact() { Phone = "1234567897", Email = "cust3@mail.com" };

        //Customer
        var customer1 = new Customer() { Name = "Sanan", Surname = "Gambarov", Contact = contact1 };
        var customer2 = new Customer() { Name = "Tarlan", Surname = "Huseynzade", Contact = contact2 };
        var customer3 = new Customer() { Name = "Kamran", Surname = "Piriyev", Contact = contact3 };

        var customers = new List<Customer>() { customer1, customer2, customer3 };

        //Order
        var orders = new List<Order>()
        {
            new Order(){Product = product4, Customer = customer2, SalesDate = new DateOnly(2025, 9, 9), Quantity = 2 },
            new Order(){Product = product1, Customer = customer2, SalesDate = new DateOnly(2025, 3, 7), Quantity = 1 },
            new Order(){Product = product9, Customer = customer3, SalesDate = new DateOnly(2025, 8, 6), Quantity = 4 },
            new Order(){Product = product8, Customer = customer1, SalesDate = new DateOnly(2025, 2, 26), Quantity = 1 },
            new Order(){Product = product9, Customer = customer1, SalesDate = new DateOnly(2025, 6, 25), Quantity = 4 },
            new Order(){Product = product6, Customer = customer1, SalesDate = new DateOnly(2025, 10, 27), Quantity = 4 },
            new Order(){Product = product6, Customer = customer1, SalesDate = new DateOnly(2025, 4, 25), Quantity = 2 },
            new Order(){Product = product2, Customer = customer1, SalesDate = new DateOnly(2025, 9, 15), Quantity = 1 },
            new Order(){Product = product7, Customer = customer3, SalesDate = new DateOnly(2025, 12, 6), Quantity = 1 },
            new Order(){Product = product2, Customer = customer2, SalesDate = new DateOnly(2025, 11, 25), Quantity = 3 },
            new Order(){Product = product2, Customer = customer2, SalesDate = new DateOnly(2025, 7, 17), Quantity = 5 },
            new Order(){Product = product4, Customer = customer2, SalesDate = new DateOnly(2025, 8, 17), Quantity = 5 },
            new Order(){Product = product3, Customer = customer3, SalesDate = new DateOnly(2025, 6, 9), Quantity = 5 },
            new Order(){Product = product5, Customer = customer1, SalesDate = new DateOnly(2025, 11, 20), Quantity = 3 },
            new Order(){Product = product3, Customer = customer2, SalesDate = new DateOnly(2025, 6, 2), Quantity = 2 },
            new Order(){Product = product2, Customer = customer2, SalesDate = new DateOnly(2025, 2, 27), Quantity = 5 },
            new Order(){Product = product1, Customer = customer1, SalesDate = new DateOnly(2025, 5, 26), Quantity = 5 },
            new Order(){Product = product5, Customer = customer1, SalesDate = new DateOnly(2025, 4, 20), Quantity = 3 },
            new Order(){Product = product2, Customer = customer2, SalesDate = new DateOnly(2025, 9, 4), Quantity = 1 },
            new Order(){Product = product5, Customer = customer2, SalesDate = new DateOnly(2025, 6, 23), Quantity = 5 },
            new Order(){Product = product5, Customer = customer1, SalesDate = new DateOnly(2025, 6, 2), Quantity = 1 },
            new Order(){Product = product7, Customer = customer3, SalesDate = new DateOnly(2025, 4, 25), Quantity = 4 },
            new Order(){Product = product8, Customer = customer3, SalesDate = new DateOnly(2025, 9, 26), Quantity = 5 },
            new Order(){Product = product4, Customer = customer3, SalesDate = new DateOnly(2025, 8, 25), Quantity = 3 },
            new Order(){Product = product8, Customer = customer2, SalesDate = new DateOnly(2025, 5, 12), Quantity = 2 },
            new Order(){Product = product8, Customer = customer2, SalesDate = new DateOnly(2025, 1, 14), Quantity = 5 },
            new Order(){Product = product1, Customer = customer1, SalesDate = new DateOnly(2025, 6, 14), Quantity = 1 },
            new Order(){Product = product8, Customer = customer2, SalesDate = new DateOnly(2025, 5, 24), Quantity = 2 },
            new Order(){Product = product6, Customer = customer2, SalesDate = new DateOnly(2025, 8, 16), Quantity = 4 },
            new Order(){Product = product5, Customer = customer2, SalesDate = new DateOnly(2025, 9, 22), Quantity = 1 },
            new Order(){Product = product4, Customer = customer2, SalesDate = new DateOnly(2025, 9, 1), Quantity = 3 },
            new Order(){Product = product1, Customer = customer3, SalesDate = new DateOnly(2025, 5, 17), Quantity = 3 },
            new Order(){Product = product7, Customer = customer1, SalesDate = new DateOnly(2025, 3, 16), Quantity = 2 },
            new Order(){Product = product2, Customer = customer2, SalesDate = new DateOnly(2025, 4, 25), Quantity = 4 },
            new Order(){Product = product9, Customer = customer1, SalesDate = new DateOnly(2025, 6, 18), Quantity = 2 },
            new Order(){Product = product1, Customer = customer3, SalesDate = new DateOnly(2025, 8, 9), Quantity = 5 },
            new Order(){Product = product1, Customer = customer3, SalesDate = new DateOnly(2025, 3, 4), Quantity = 3 },
            new Order(){Product = product7, Customer = customer3, SalesDate = new DateOnly(2025, 5, 1), Quantity = 2 },
            new Order(){Product = product8, Customer = customer1, SalesDate = new DateOnly(2025, 1, 24), Quantity = 3 },
            new Order(){Product = product3, Customer = customer2, SalesDate = new DateOnly(2025, 3, 23), Quantity = 5 },
            new Order(){Product = product7, Customer = customer3, SalesDate = new DateOnly(2025, 12, 3), Quantity = 4 },
            new Order(){Product = product7, Customer = customer2, SalesDate = new DateOnly(2025, 8, 18), Quantity = 2 },
            new Order(){Product = product9, Customer = customer3, SalesDate = new DateOnly(2025, 2, 19), Quantity = 1 },
            new Order(){Product = product5, Customer = customer1, SalesDate = new DateOnly(2025, 2, 1), Quantity = 3 },
            new Order(){Product = product9, Customer = customer2, SalesDate = new DateOnly(2025, 5, 4), Quantity = 1 },
            new Order(){Product = product8, Customer = customer1, SalesDate = new DateOnly(2025, 7, 16), Quantity = 2 },
            new Order(){Product = product6, Customer = customer1, SalesDate = new DateOnly(2025, 11, 4), Quantity = 5 },
            new Order(){Product = product7, Customer = customer2, SalesDate = new DateOnly(2025, 7, 4), Quantity = 4 },
            new Order(){Product = product2, Customer = customer3, SalesDate = new DateOnly(2025, 11, 3), Quantity = 2 },
            new Order(){Product = product4, Customer = customer1, SalesDate = new DateOnly(2025, 10, 16), Quantity = 4 },
            new Order(){Product = product5, Customer = customer3, SalesDate = new DateOnly(2025, 12, 11), Quantity = 2 },
            new Order(){Product = product5, Customer = customer2, SalesDate = new DateOnly(2025, 8, 14), Quantity = 1 }
        };

        //Program Initializer Service
        var initializer = new ProgramInitializerService() { Service = "InitProgram Datas", Value = "yes" };

        //final
        _unitOfWork.ProgramInitializerServices.Add(initializer);
        _unitOfWork.Orders.AddRange(orders);
        _unitOfWork.Customers.AddRange(customers);
        _unitOfWork.Products.AddRange(products);
        _unitOfWork.ProductCategories.AddRange(categories);
        _unitOfWork.Save();
    }

    //---------------------------------------------------------------------------

    public void AddProductProcess()
    {
        string productName = "";
        int quantity = 0;
        decimal price = 0;
        int categorySelect = 0;
        int categorySelect1 = 0;
        ProductCategory category = null;

        Console.Write("Product name: ");
        productName = Console.ReadLine();

        Console.Write("Quantity: ");
        quantity = int.Parse(Console.ReadLine());

        Console.Write("Sales price: ");
        price = decimal.Parse(Console.ReadLine());

        Console.Write("Category: ");
        Console.Write("Select from existing categories(1) or add a new category(2): ");
        categorySelect = int.Parse(Console.ReadLine());
        switch (categorySelect)
        {
            case 1:
                _unitOfWork.ShowAllCategories();
                categorySelect1 = _commonBehaviour.Select();
                category = _unitOfWork.GetProductCategoryById(categorySelect1);
                break;
            case 2:
                category = AddCategoryProcess();
                break;
            default:
                category = AddCategoryProcess();
                break;
        }

        _unitOfWork.AddProduct(
            new Product()
            {
                ProductName = productName,
                Quantity = quantity,
                SalesPrice = price,
                ProductCategory = category
            }
        );
    }

    public void RemoveProductProcess()
    {
        int selection = 0;

        _unitOfWork.ShowAllProducts2();

        Console.Write("Select id: ");
        selection = int.Parse(Console.ReadLine());

        var product = new Product() { Id = selection };
        _unitOfWork.RemoveProduct(product);
    }

    public void UpdateProductProcess()
    {
        int selection = 0;
        int quantity = 0;

        _unitOfWork.ShowAllProducts2();

        Console.Write("Select id: ");
        selection = int.Parse(Console.ReadLine());

        Console.Write("Add new quantity: ");
        quantity = int.Parse(Console.ReadLine());

        var product = new Product() { Id = selection, Quantity = quantity };
        _unitOfWork.UpdateProduct(product);
    }

    public void AddCustomerProcess()
    {
        string name = "";
        string surname = "";
        string phone = "";
        string email = "";

        Console.Clear();

        Console.Write("Name: ");
        name = Console.ReadLine();

        Console.Write("Surname: ");
        surname = Console.ReadLine();

        Console.Write("Phone: ");
        phone = Console.ReadLine();

        Console.Write("Email: ");
        email = Console.ReadLine();

        var contact = new Contact()
        {
            Phone = phone,
            Email = email
        };

        var customer = new Customer()
        {
            Name = name,
            Surname = surname,
            Contact = contact
        };

        _unitOfWork.AddCustomer(customer);
    }

    public void RemoveCustomerProcess()
    {
        int selection = 0;
        int contactId = 0;

        Console.Clear();
        _unitOfWork.ShowAllCustomers();

        Console.Write("Select id: ");
        selection = int.Parse(Console.ReadLine());

        //secilen customerin contact id si elde edilir (paralel olaraq contact-dan da silinir)
        contactId = _unitOfWork.Customers.FirstOrDefault(c => c.Id == selection).ContactId;

        var customer = new Customer() { Id = selection };
        var contact = new Contact() { Id = contactId };

        _unitOfWork.RemoveCustomer(customer);
        _unitOfWork.RemoveContact(contact);
    }

    public ProductCategory AddCategoryProcess()
    {
        ProductCategory category = null;
        string categoryName = "";

        Console.Write("Category name: ");
        categoryName = Console.ReadLine();

        category = new ProductCategory() { Category = categoryName };

        _unitOfWork.AddCategory(category);

        return category;
    }

    public void AddOrderProcess()
    {
        int productId = 0;
        int customerId = 0;
        int currentQuantity = 0;
        int quantity = 0;

        Console.Clear();

        _unitOfWork.ShowAllCustomers();
        Console.Write("Select customer id: ");
        customerId = int.Parse(Console.ReadLine());

        Console.Clear();

        _unitOfWork.ShowProductsByCategories();
        Console.Write("Select product id: ");
        productId = int.Parse(Console.ReadLine());

        var product = _unitOfWork.GetProductById(productId);
        currentQuantity = product.Quantity;

        Console.Write("Quantity: ");
        quantity = int.Parse(Console.ReadLine());

        if (currentQuantity >= quantity)
        {
            _unitOfWork.AddOrder(
                new Order()
                {
                    ProductId = productId,
                    CustomerID = customerId,
                    SalesDate = DateOnly.FromDateTime(DateTime.Now),
                    Quantity = quantity
                }
            );
        }
        else
        {
            Console.WriteLine("There is not enough product in the storage");
        }
    }

    public bool ReportingProcess()
    {
        bool result = true;
        int selection = 0;
        Menu.menu2();
        selection = _commonBehaviour.Select();
        Console.Clear();

        switch (selection)
        {
            case 1:
                _unitOfWork.ShowAllCustomers();
                break;
            case 2:
                _unitOfWork.ShowAllProducts();
                break;
            case 3:
                _unitOfWork.ShowAllTransactions();
                break;
            case 4:
                _unitOfWork.TotalCustomerCount();
                break;
            case 5:
                _unitOfWork.TotalProductCount();
                break;
            case 6:
                _unitOfWork.TotalRevenue();
                break;
            case 7:
                _unitOfWork.TotalQuantitySold();
                break;
            default:
                result = false;
                break;
        }

        return result;
    }
}
