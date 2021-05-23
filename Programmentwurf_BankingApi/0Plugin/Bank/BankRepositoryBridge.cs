using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi._1Adapter.Bank;
using Programmentwurf_BankingApi._3Domain.Aggregates;
using Programmentwurf_BankingApi._3Domain.Repositories;
using Programmentwurf_BankingApi.Domain.Entities;
using Programmentwurf_BankingApi.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._0Plugin.Bank
{
    public class BankRepositoryBridge : BankRepository
    {
        private BankingContext Context;

        public BankRepositoryBridge(BankingContext context)
        {
            Context = context;
        }
        public async void create(BankAggregate bank)
        {
                Context.BankAggregate.Add(bank);
                await Context.SaveChangesAsync();
        }
        public async void delete(int bankid)
        {
            var bank = await Context.BankAggregate.FindAsync(bankid);
            if(bank == null)
            {
                return;
            }
            Context.BankAggregate.Remove(bank);
            await Context.SaveChangesAsync();
        }
        public async Task<List<BankAggregate>> getAllBanks()
        {
            return await Context.BankAggregate.ToListAsync();
        }
        public async Task<BankAggregate> findById(int bankid)
        {
            return await Context.BankAggregate.FindAsync(bankid);
        }
        public async Task<List<KontoEntity>> getKonten(string bic)
        {
            return await Context.Konten.Where(x => x.BIC == bic).ToListAsync();
        }
        private bool BankAggregateExists(string bic)
        {
            return Context.BankAggregate.Any(e => e.Bank.BIC == bic);
        }
    }
}
