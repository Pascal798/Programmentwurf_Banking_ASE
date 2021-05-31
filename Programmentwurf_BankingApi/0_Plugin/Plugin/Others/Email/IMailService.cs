using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Plugin.Others
{
     public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
