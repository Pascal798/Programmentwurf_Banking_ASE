using System.Collections.Generic;
using _3_Domain.Domain.Aggregates;

namespace _1_Adapter.Adapter.Bank
{
    public class BankMapper
    {
        private static BankMapper instance;
        public static BankMapper getInstance() 
        {
            if(instance == null)
            {
                instance = new BankMapper();
            }
            return instance;
        }
        public Bank apply(BankAggregate bank)
        {
            return map(bank);
        }

        private Bank map(BankAggregate bank)
        {
            return new Bank(bank.Bank.Name, bank.Bank.BIC, bank.Adresse.getLand(), bank.Adresse.getPLZ(), bank.Adresse.getStraße());
        }
        public List<Bank> convertToBankResourceList(List<BankAggregate> bankAggregates)
        {
            var bankList = new List<Bank>();
            foreach (var bank in bankAggregates)
            {
                bankList.Add(new Bank(
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
