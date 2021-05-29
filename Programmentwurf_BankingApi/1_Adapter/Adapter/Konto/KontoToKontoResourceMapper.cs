using System.Collections.Generic;
using _3_Domain.Domain.Entities;

namespace _1_Adapter.Adapter.Konto
{
    public class KontoToKontoResourceMapper
    {
        private static KontoToKontoResourceMapper instance;
        public static KontoToKontoResourceMapper getInstance()
        {
            if(instance == null)
            {
                instance = new KontoToKontoResourceMapper();
            }
            return instance;
        }
        public KontoResource apply(KontoEntity konto)
        {
            return map(konto);
        }

        private KontoResource map(KontoEntity konto)
        {
            return new KontoResource(
                konto.Id,
                konto.UserId
            );
        }
        public List<KontoResource> convertToKontoResourceList(List<KontoEntity> kontoEntities)
        {
            var kontolist = new List<KontoResource>();
            foreach (var kontoEntity in kontoEntities)
            {
                kontolist.Add(new KontoResource(kontoEntity.Id, kontoEntity.UserId));
            }
            return kontolist;
        }
    }
}
