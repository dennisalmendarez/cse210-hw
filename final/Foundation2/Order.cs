using System;
public class Order {

    private List<Product> _products;
    private string _customer;

    public Order(string customer){
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product){
        _products.Add(product);
    }

    public int GetTotalCost(){
        return _products.Sum(product => product.GetCalculatePrice());
    }


}