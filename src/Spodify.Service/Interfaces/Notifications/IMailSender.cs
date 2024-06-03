using Spodify.Service.Dtos;
namespace Spodify.Service.Interfaces.Notifications;

public interface IMailSender
{
    public Task<bool> SendAsync(EmailMessage message);
}
