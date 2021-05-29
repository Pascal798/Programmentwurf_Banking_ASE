using System.Collections.Generic;
using _1_Adapter.Adapter.Konto;
using _3_Domain.Domain.Entities;
using Xunit;

namespace Programmentwurf_BankingApi.Adapter.Konto.Tests
{
    public class KontoToKontoResourceMapperTests
    {
        [Fact]
        public void convertToKontoResourceListTest()
        {
            var konten = CreateKonten();
            var kontoArray = konten.ToArray();
            var kontolist = KontoToKontoResourceMapper.getInstance().convertToKontoResourceList(konten).ToArray();


            for (int i = 0; i < kontoArray.Length; i++)
            {
                Assert.Equal(kontoArray[i].Id, kontolist[i].Id);
                Assert.Equal(kontoArray[i].UserId, kontolist[i].UserId);
            }
        }

        private static List<KontoEntity> CreateKonten()
        {
            var kontoEntities = new List<KontoEntity>();
            for (int i = 0; i <= 10; i++)
            {
                kontoEntities.Add(new KontoEntity(i, i, "GENODE" + i));
            }
            return kontoEntities;
        }

        [Fact]
        public void applyTest()
        {
            var konto = new KontoEntity(1, 1, "GENODE" + 1);
            var kontoResource = KontoToKontoResourceMapper.getInstance().apply(konto);

            Assert.Equal(konto.Id, kontoResource.Id);
            Assert.Equal(konto.UserId, kontoResource.UserId);
        }
    }
}