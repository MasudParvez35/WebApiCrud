using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Core.Domain;

public class Product : BaseEntity
{ 
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
