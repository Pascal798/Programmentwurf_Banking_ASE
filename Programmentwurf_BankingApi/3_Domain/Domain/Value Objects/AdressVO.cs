namespace _3_Domain.Domain.Value_Objects
{
    public sealed class AdressVO
    {
        public AdressVO() { }
        public AdressVO(string land, int plz, string straße)
        {
            Land = land;
            Postleitzahl = plz;
            Straße = straße;
        }

        public string Land { get; set; }
        public int Postleitzahl { get; set; }
        public string Straße { get; set; }
        

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
