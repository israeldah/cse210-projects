using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    private const double _domesticShipping = 5.0;
    private const double _internationalShipping = 35.0;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = _customer.LivesInUSA() ? _domesticShipping : _internationalShipping;
        foreach (var product in _products)
            total += product.GetTotalCost();
        return total;
    }

    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("--- Packing Label ---");
        foreach (var product in _products)
            sb.AppendLine(product.GetPackingLabel());
        return sb.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"--- Shipping Label ---\n{_customer.GetShippingLabel()}";
    }
}
