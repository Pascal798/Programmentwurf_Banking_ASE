using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3_Domain.Domain.Aggregates;
using _3_Domain.Domain.Repositories;

namespace _2_Application.Application
{
    public class BankApplicationService : BankRepository
    {
        private BankRepository BankRepository;

        public BankApplicationService(BankRepository bankRepository)
        {
            BankRepository = bankRepository;
        }

        public Task<bool> bankAnlegen(BankAggregate bank)
        {
            return BankRepository.bankAnlegen(bank);
        }

        public Task<List<BankAggregate>> getAllBanks()
        {
            return BankRepository.getAllBanks();
        }

        public Task<BankAggregate> findById(int bankid)
        {
            return BankRepository.findById(bankid);
        }

        public Task<bool> bankLöschen(int bankid)
        {
            return BankRepository.bankLöschen(bankid);
        }
    }
}
