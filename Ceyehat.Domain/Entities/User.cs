namespace Ceyehat.Domain.Entities;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;

    public Customer Customer { get; set; } = null!;
}