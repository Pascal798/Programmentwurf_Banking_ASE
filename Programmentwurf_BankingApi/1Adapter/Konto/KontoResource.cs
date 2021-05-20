using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.Konto
{
    public class KontoResource
    {
        public KontoResource(int userid, double kontostand)
        {
            UserId = userid;
            Kontostand = kontostand;
        }

        public int UserId { get; set; }
        public double Kontostand { get; set; }

    }
}
