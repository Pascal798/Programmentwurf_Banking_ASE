using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._3Domain.Value_Objects
{
    public sealed class TransactionVO
    {

        public int Id { get; set; }
        public double Betrag { get; set; }
        public int KontoIdSender { get; set; }
        public int KontoIdEmpfänger { get; set; }

        public double getBetrag()
        {
            return Betrag;
        }
        public int getKontoIdSender()
        {
            return KontoIdSender;
        }
        public int getKontoIdEmpfänger()
        {
            return KontoIdEmpfänger;
        }
    }
}
