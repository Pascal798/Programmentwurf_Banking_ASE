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
        public KontoModel(double kontostand, int userId, string bic)
        {
            Kontostand = kontostand;
            UserId = userId;
            BIC = bic;
        }

        public KontoModel(int id, int userId, string bIC)
        {
            Id = id;
            UserId = userId;
            BIC = bIC;
        }

        public int Id { get; set; }
        public double Kontostand { get; set; }
        public int UserId { get; set; }
        public string BIC { get; set; }
        
    }
}
