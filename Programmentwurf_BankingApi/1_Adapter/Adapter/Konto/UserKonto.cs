namespace _1_Adapter.Adapter.Konto
{
    public class UserKonto
    {
        public UserKonto() { }

        public UserKonto(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

    }
}
