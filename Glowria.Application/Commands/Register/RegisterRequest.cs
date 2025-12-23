namespace Glowria.Application.Commands.Register;

public class RegisterRequest
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Confirmpassword { get; set; } = default!;
}