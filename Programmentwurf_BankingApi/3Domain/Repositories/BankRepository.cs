using Programmentwurf_BankingApi._3Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._3Domain.Repositories
{
    public interface BankRepository
    {
        void create(BankAggregate bank);
        void delete(int bankid);
        Task<List<BankAggregate>> getAllBanks();
        Task<BankAggregate> findById(int bankid);
    }
}
