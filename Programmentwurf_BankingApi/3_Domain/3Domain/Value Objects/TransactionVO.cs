namespace Programmentwurf_BankingApi._3Domain.Value_Objects
{
    public sealed class TransactionVO
    {
        public TransactionVO(double betrag, int kontoIdSender, int kontoIdEmpfänger)
        {
            Betrag = betrag;
            KontoIdSender = kontoIdSender;
            KontoIdEmpfänger = kontoIdEmpfänger;
        }

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
