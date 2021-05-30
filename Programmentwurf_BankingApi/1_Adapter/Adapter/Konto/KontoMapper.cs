using System.Collections.Generic;
using _3_Domain.Domain.Entities;

namespace _1_Adapter.Adapter.Konto
{
    public class KontoMapper
    {
        private static KontoMapper instance;
        public static KontoMapper getInstance()
        {
            if(instance == null)
            {
                instance = new KontoMapper();
            }
            return instance;
        }
        public UserKonto apply(KontoEntity konto)
        {
            return map(konto);
        }

        private UserKonto map(KontoEntity konto)
        {
            return new UserKonto(
                konto.Id,
                konto.UserId
            );
        }
        public List<UserKonto> convertToKontoResourceList(List<KontoEntity> kontoEntities)
        {
            var kontolist = new List<UserKonto>();
            foreach (var kontoEntity in kontoEntities)
            {
                kontolist.Add(new UserKonto(kontoEntity.Id, kontoEntity.UserId));
            }
            return kontolist;
        }
    }
}
