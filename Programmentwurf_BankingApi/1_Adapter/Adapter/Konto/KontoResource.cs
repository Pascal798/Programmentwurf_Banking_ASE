using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.Konto
{
    public class KontoResource
    {
        public KontoResource(string bic, double kontostand)
        {
            BIC = bic;
            Kontostand = kontostand;
        }
        public KontoResource() { }

        public KontoResource(int id, int userId, string bIC)
        {
            Id = id;
            UserId = userId;
            BIC = bIC;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string BIC { get; set; }
        public double Kontostand { get; set; }

    }
}
