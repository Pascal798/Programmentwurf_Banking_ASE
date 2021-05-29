using System.Collections.Generic;
using _3_Domain.Domain.Aggregates;

namespace _1_Adapter.Adapter.Bank
{
    public class BankToBankResourceMapper
    {
        private static BankToBankResourceMapper instance;
        public static BankToBankResourceMapper getInstance() 
        {
            if(instance == null)
            {
                instance = new BankToBankResourceMapper();
            }
            return instance;
        }
        public BankResource apply(BankAggregate bank)
        {
            return map(bank);
        }

        private BankResource map(BankAggregate bank)
        {
            return new BankResource(bank.Bank.Name, bank.Bank.BIC, bank.Adresse.getLand(), bank.Adresse.getPLZ(), bank.Adresse.getStraße());
        }
        public List<BankResource> convertToBankResourceList(List<BankAggregate> bankAggregates)
        {
            var bankList = new List<BankResource>();
            foreach (var bank in bankAggregates)
            {
                bankList.Add(new BankResource(
                    bank.Bank.Name,
                    bank.Bank.BIC,
                    bank.Adresse.getLand(),
                    bank.Adresse.getPLZ(),
                    bank.Adresse.getStraße()));
            }
            return bankList;
        }
    }
}
