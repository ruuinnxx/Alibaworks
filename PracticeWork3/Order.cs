namespace Project1_Order;

public class Order(List<Product?> products)
{
    public double TotalPrice => products.Sum(p => p?.Price ?? 0);
    public void AddProduct(Product? product) =>
        products.Add(product);
}