using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Domain.Repositories
{
    public interface TransactionRepository
    {
        void create(TransactionEntity transaction);
        Task<List<TransactionEntity>> getAllTransactions(int userid);
        Task<IActionResult> getTransactionsAsMail(int kontoid);
    }
}
