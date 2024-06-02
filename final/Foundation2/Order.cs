using System;
public class Order {

    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer){
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product){
        _products.Add(product);
    }
    

    public double CalculateTotalCost(){
        double total = 0;
        foreach (var product in _products){
            total += product.CalculateTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public double GetShippingCost(){
        double shippingCost = _customer.IsInUSA() ? 5 : 35;
        return shippingCost;
    }

    public string GetPackingLabel(){
        string label = "Paking Label:\n";
        foreach (var product in _products){
            label += $"{product.GetName()} (ID: {product.GetProductID()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}