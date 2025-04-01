namespace OnlineOrdering;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product prduct)
    {
        _products.Add(prduct);
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;
        
        foreach (Product product in _products)
            totalPrice += product.GetTotalPrice();
        
        return totalPrice + (_customer.IsInUSA() ? 5 : 35);
    }

    public string PackingSlip()
    {
        string label = "Packing Label:\n";
        
        foreach (Product product in _products)
            label += $"{product.GetDetails()}\n";
        

        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping To:\n{_customer.GetDetails()}";
    }
}