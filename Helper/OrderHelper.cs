using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using IMC_codeChallenge.Model;
namespace IMC_codeChallenge.Helper;

public class OrderHelper
{
    public static Order GenerateOrder()
    {
       // List<Order> orders = new List<Order>();
        Order order = new Order();
        order.products = generateProducts();
        order.subTotal = order.products.Sum(x => x.price * x.quantity);
       // orders.Add(order);

        return order;
    }

    private static List<Product> generateProducts()
    {
        List<Product> products = new List<Product>();
        Product product1 = new Product();
        product1.price = 10.00;
        product1.quantity = 1;
        product1.productName = "Picture Book";
        
        Product product2 = new Product();
        product2.price = 5.00;
        product2.quantity = 2;
        product2.productName = "Coffee Cup";
        
        Product product3 = new Product();
        product3.price = 150.00;
        product3.quantity = 1;
        product3.productName = "Computer Monitor";
        
        products.Add(product1);
        products.Add(product2);
        products.Add(product3);

        return products;
    }
}