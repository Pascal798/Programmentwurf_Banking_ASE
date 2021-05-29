using System.Threading.Tasks;

namespace _3_Domain.Domain.Others.Email
{
     public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
