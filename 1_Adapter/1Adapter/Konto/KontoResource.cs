using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.Konto
{
    public class KontoResource
    {
        public KontoResource(int kontoid, string bic, double kontostand)
        {
            KontoId = kontoid;
            BIC = bic;
            Kontostand = kontostand;
        }
        public KontoResource(string bic, double kontostand)
        {
            BIC = bic;
            Kontostand = kontostand;
        }
        public KontoResource() { }

        public int KontoId { get; set; }
        public string BIC { get; set; }
        public double Kontostand { get; set; }

    }
}
