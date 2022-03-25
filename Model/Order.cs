using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace IMC_codeChallenge.Model;

public class Order
{
    public string OrderId { get; set; }
    public string orderNumber { get; set; }
    public DateTime orderDate { get; set; }
    public double subTotal { get; set; }
    public double taxRate { get; set; }
    public double total { get; set; }
    public List<Product> products { get; set; }

    public Order()
    {
        OrderId = Guid.NewGuid().ToString();
        orderNumber = GenerateOrderNumber();
        orderDate = DateTime.Now;
    }
    
    private static string GenerateOrderNumber()
    {
        Random random = new Random();
        const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
        var chars = Enumerable.Range(0, 5)
            .Select(x => pool[random.Next(0, pool.Length)]);
        return new string(chars.ToArray());
    }

}