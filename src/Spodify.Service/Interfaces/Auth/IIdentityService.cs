namespace Spodify.Service.Interfaces.Auth;

public interface IIdentityService
{
    public int Id { get; }

    public string UserName { get; }

    public string Email { get; }
}
