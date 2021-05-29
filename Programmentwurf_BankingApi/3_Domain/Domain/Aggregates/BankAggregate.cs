using _3_Domain.Domain.Entities;
using _3_Domain.Domain.Value_Objects;

namespace _3_Domain.Domain.Aggregates
{
    public class BankAggregate
    {
        public BankAggregate() { }
        public BankAggregate(string name, string bic, string land, int plz, string straße)
        {
            Bank = new BankEntity(name, bic);
            Adresse = new AdressVO(land, plz, straße);
        }
        public BankAggregate(int id, string name, string bic, string land, int plz, string straße)
        {
            Id = id;
            Bank = new BankEntity(name, bic);
            Adresse = new AdressVO(land, plz, straße);
        }
        public int Id { get; set; }
        public BankEntity Bank { get; set; }
        public AdressVO Adresse { get; set; }
    }
}
