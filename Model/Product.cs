using System;
namespace IMC_codeChallenge.Model;

public class Product
{
    public string productId { get; set; } 
    public int quantity { get; set; }
    public double price { get; set; }
    public string productName { get; set; }

    public Product()
    {
        productId = Guid.NewGuid().ToString();
    }
}
