using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._1Adapter.Bank
{
    public class BankResource
    {
        public BankResource(string name, string bic, string land, int postleitzahl, string straße)
        {
            Name = name;
            BIC = bic;
            Land = land;
            Postleitzahl = postleitzahl;
            Straße = straße;
        }

        public string Name { get; set; }
        public string BIC { get; set; }
        public string Land { get; set; }
        public int Postleitzahl { get; set; }
        public string Straße { get; set; }
    }
}
