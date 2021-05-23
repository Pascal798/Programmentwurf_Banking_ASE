namespace Programmentwurf_BankingApi.Domain.Entities
{
    public class KontoEntity
    {
        public KontoEntity() { }
        public KontoEntity(int kontoid, double kontostand, int userid, string bic)
        {
            Id = kontoid;
            Kontostand = kontostand;
            UserId = userid;
            BIC = bic;
        }
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
