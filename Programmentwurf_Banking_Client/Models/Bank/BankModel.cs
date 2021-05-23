using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmentwurf_Banking_Client.Models.Bank
{
    public class BankModel
    {
        public BankModel(string name, string bIC, string land, int postleitzahl, string straße)
        {
            Name = name;
            BIC = bIC;
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
