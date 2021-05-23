using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmentwurf_Banking_Client.Models.Konto
{
    public class KontoModel
    {
        public KontoModel() { }
        public KontoModel(int kontoId, string bic, double kontostand)
        {
            KontoId = kontoId;
            BIC = bic;
            Kontostand = kontostand;
        }
        public KontoModel(string bic, double kontostand)
        {
            BIC = bic;
            Kontostand = kontostand;
        }

        public int KontoId { get; set; }
        public string BIC { get; set; }
        public double Kontostand { get; set; }
    }
}
