using System.Collections.Generic;
using System.Threading.Tasks;
using _3_Domain.Domain.Aggregates;

namespace _3_Domain.Domain.Repositories
{
    public interface BankRepository
    {
        Task<bool> create(BankAggregate bank);
        Task<bool> delete(int bankid);
        Task<List<BankAggregate>> getAllBanks();
        Task<BankAggregate> findById(int bankid);
    }
}
