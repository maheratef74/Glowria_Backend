namespace Identity.Domain.Entities;

public class Customer : ApplicationUser
{
    public string Address { get; set; }
}