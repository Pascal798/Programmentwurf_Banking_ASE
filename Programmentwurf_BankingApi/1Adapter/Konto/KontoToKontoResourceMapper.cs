using Programmentwurf_BankingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.Konto
{
    public class KontoToKontoResourceMapper
    {
        public KontoResource apply(KontoEntity konto)
        {
            return map(konto);
        }

        private KontoResource map(KontoEntity konto)
        {
            return new KontoResource(
                konto.UserId, 
                konto.Kontostand
                );
        }
    }
}
