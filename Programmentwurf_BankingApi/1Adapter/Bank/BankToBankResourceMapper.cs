using Programmentwurf_BankingApi._3Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._1Adapter.Bank
{
    public class BankToBankResourceMapper
    {
        public BankResource apply(BankAggregate bank)
        {
            return map(bank);
        }

        private BankResource map(BankAggregate bank)
        {
            return new BankResource(bank.Bank.Name, bank.Bank.BIC, bank.Adresse.getLand(), bank.Adresse.getPLZ(), bank.Adresse.getStraße());
        }
    }
}
