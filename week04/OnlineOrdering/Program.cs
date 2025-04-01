namespace OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 USA St", "USA CIty", "USA State", "USA");
        Address address2 = new Address("123 USA St", "USA CIty", "USA State", "USA");


        Customer customer1 = new Customer("Katlego Kgwetiane", address1);
        Customer customer2 = new Customer("Rumbidzai Kgwetiane", address2);


        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);


        order1.AddProduct(new Product("Dell Latitude 7440", "P001", 1000m, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25m, 1));

        order2.AddProduct(new Product("Dell Latitude 7420", "P003", 50m, 1));
        order2.AddProduct(new Product("Monitor", "P004", 200m, 2));


        Console.WriteLine(order1.PackingSlip());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalPrice()}\n");

        Console.WriteLine(order2.PackingSlip());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalPrice()}");
    }
}