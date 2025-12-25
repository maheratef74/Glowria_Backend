namespace Glowria.Domain.Entities;

public class Product
{
    public Guid Id { get; set; } = new Guid();
    
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    
    public string? DescriptionEn { get; set; }
    public string? DescriptionAr { get; set; }
    
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    
    public string? Size { get; set; } // 200ml, 50g

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public bool IsFeatured { get; private set; }
    public bool IsActive { get; private set; }
}