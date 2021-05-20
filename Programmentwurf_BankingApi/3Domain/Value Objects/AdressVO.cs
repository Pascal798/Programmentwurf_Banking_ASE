using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._3Domain.Value_Objects
{
    public sealed class AdressVO
    {
        public int Id { get; set; }
        public string Land { get; set; }
        public int Postleitzahl { get; set; }
        public string Straße { get; set; }
        
        public int getId()
        {
            return Id;
        }

        public void setId(int id)
        {
            Id = id;
        }

        public string getLand()
        {
            return Land;
        }

        public void setLand(string land)
        {
            Land = land;
        }

        public int getPLZ()
        {
            return Postleitzahl;
        }

        public void setPLZ(int plz)
        {
            Postleitzahl = plz;
        }
        public string getStraße()
        {
            return Straße;
        }

        public void setStraße(string straße)
        {
            Straße = straße;
        }
    }
}
