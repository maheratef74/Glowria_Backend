namespace Glowria.Domain.Entities;

public class Category
{
    public Guid Id { get; set; } = new Guid();
    
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    
    public bool IsActive { get; private set; }
    
    public string? DescriptionEn { get; set; }
    public string? DescriptionAr { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}