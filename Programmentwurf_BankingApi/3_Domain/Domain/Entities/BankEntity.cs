namespace _3_Domain.Domain.Entities
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
