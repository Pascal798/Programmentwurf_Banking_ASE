namespace _3_Domain.Domain.Entities
{
    public class KontoEntity
    {
        public KontoEntity() { }

        public KontoEntity(double kontostand, int userid, string bic)
        {
            Kontostand = kontostand;
            UserId = userid;
            BIC = bic;
        }

        public int Id { get; set; }
        public double Kontostand { get; set; }
        public int UserId { get; set; }
        public string BIC { get; set; }

    }
}
