using System.ComponentModel.DataAnnotations;

namespace API.Entity;

public class Product{
    [Key]
    public int Id{get; set;}
    [Required]
    public string? Name { get; set; }
    public string? Description{get; set;}
    public decimal Price{get; set;}
    public bool isActive{get; set;}
    public string? ImageUrl{get; set;}
    public int stock{get; set;}
    // `string?` -> Null olabilir (opsiyonel)
    // `string`  -> Null olamaz (zorunlu)
   
  
    
}