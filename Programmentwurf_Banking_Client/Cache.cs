using Programmentwurf_Banking_Client.Models;
using Programmentwurf_Banking_Client.Requests.Bank;
using Programmentwurf_Banking_Client.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Programmentwurf_Banking_Client
{
    public static class Cache
    {
        public static ObjectCache cache = MemoryCache.Default;

        public async static void GenerateDefaultData()
        {
            await BankProcessor.CreateBank("Volksbank Bruchsal-Bretten", "GENODE61BTT", "Deutschland", 76703, "Niwenburgstraße 17");
            await BankProcessor.CreateBank("Volksbank Karlsruhe", "GENODE61BTX", "Deutschland", 76131, "KAStraße 1");
            await BankProcessor.CreateBank("Sparkasse Karlsruhe", "GENODE61BTZ", "Deutschland", 76131, "KAStraße 2");

            await UserProcessor.RegisterUser("Test@test.com", "TestUser", "Passw0rd", true);
        }
    }
}
