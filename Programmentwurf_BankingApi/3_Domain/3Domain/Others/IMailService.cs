using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._3Domain.Others
{
     public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
