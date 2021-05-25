using Programmentwurf_BankingApi._3Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._3Domain.Entities
{
    public class BankEntity
    {
        public BankEntity() { }
        public BankEntity(string name, string bic)
        {
            Name = name;
            BIC = bic;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BIC { get; set; }
    }
}
