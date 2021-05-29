using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_Adapter.Adapter.Bank;
using _3_Domain.Domain.Aggregates;
using Xunit;

namespace Programmentwurf_BankingApi.Adapter.Bank.Tests
{
    public class BankToBankResourceMapperTests
    {
        [Fact]
        public void convertToBankResourceListTest()
        {
            var banks = CreateBanks();
            var bankArray = banks.ToArray();
            var bankList = BankToBankResourceMapper.getInstance().convertToBankResourceList(banks).ToArray();

            for (int i = 0; i < bankArray.Length; i++)
            {
                Assert.Equal(bankArray[i].Bank.Name, bankList[i].Name);
                Assert.Equal(bankArray[i].Bank.BIC, bankList[i].BIC);
                Assert.Equal(bankArray[i].Adresse.getLand(), bankList[i].Land);
                Assert.Equal(bankArray[i].Adresse.getPLZ(), bankList[i].Postleitzahl);
                Assert.Equal(bankArray[i].Adresse.getStraße(), bankList[i].Straße);
            }
        }

        private static List<BankAggregate> CreateBanks()
        {
            var banks = new List<BankAggregate>();
            for (int i = 0; i <= 10; i++)
            {
                banks.Add(new BankAggregate("Bank" + i, "GENODE" + i, "Deutschland", 76703 + i, "Teststraße " + i));
            }
            return banks;
        }

        [Fact]
        public void applyTest()
        {
            var bank = new BankAggregate("TestBank", "GENODETEST", "Deutschland", 76703, "Teststraße");
            var bankResource = BankToBankResourceMapper.getInstance().apply(bank);

            Assert.Equal(bank.Bank.Name, bankResource.Name);
            Assert.Equal(bank.Bank.BIC, bankResource.BIC);
            Assert.Equal(bank.Adresse.getLand(), bankResource.Land);
            Assert.Equal(bank.Adresse.getPLZ(), bankResource.Postleitzahl);
            Assert.Equal(bank.Adresse.getStraße(), bankResource.Straße);
        }
    }
}