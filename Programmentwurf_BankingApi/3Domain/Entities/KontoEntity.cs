namespace Programmentwurf_BankingApi.Domain.Entities
{
    public class KontoEntity
    {

        public int Id { get; set; }
        public double Kontostand { get; set; }
        public int UserId { get; set; }
        public int BankId { get; set; }

    }
}
