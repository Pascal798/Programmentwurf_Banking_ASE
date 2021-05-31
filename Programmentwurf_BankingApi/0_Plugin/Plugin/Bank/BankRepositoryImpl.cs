using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_Domain.Domain.Aggregates;
using _3_Domain.Domain.Entities;
using _3_Domain.Domain.Repositories;

namespace Programmentwurf_BankingApi.Plugin.Bank
{
    public class BankRepositoryImpl : BankRepository
    {
        private readonly IBankingContext _context;

        public BankRepositoryImpl(IBankingContext context)
        {
            _context = context;
        }
        public async Task<bool> bankAnlegen(BankAggregate bank)
        {
            if(!_context.BankAggregate.Any( x => x.Bank.BIC == bank.Bank.BIC))
            {
                _context.BankAggregate.Add(bank);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
        public async Task<bool> bankLöschen(int bankid)
        {
            var bank = await _context.BankAggregate.FindAsync(bankid);
            if(bank == null)
            {
                return false;
            }
            _context.BankAggregate.Remove(bank);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<BankAggregate>> getAllBanks()
        {
            return await _context.BankAggregate.ToListAsync();
        }
        public async Task<BankAggregate> findById(int bankid)
        {
            return await _context.BankAggregate.FindAsync(bankid);
        }
        private bool BankAggregateExists(string bic)
        {
            return _context.BankAggregate.Any(e => e.Bank.BIC == bic);
        }
    }
}
