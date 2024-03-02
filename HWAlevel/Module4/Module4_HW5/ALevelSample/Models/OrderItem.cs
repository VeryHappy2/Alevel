namespace ALevelSample.Models;

public class OrderItem
{
    public int BaseId { get; set; }

    public int OrderId { get; set; }

    public int Count { get; set; }

    public string ProductId { get; set; }

    public Product? Product { get; set; }
}