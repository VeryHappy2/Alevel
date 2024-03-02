using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ALevelSample.Data.Entities;

public class ProductEntity
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }

    public List<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
}