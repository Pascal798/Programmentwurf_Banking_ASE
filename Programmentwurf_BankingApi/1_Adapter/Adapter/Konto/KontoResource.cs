namespace _1_Adapter.Adapter.Konto
{
    public class KontoResource
    {
        public KontoResource() { }

        public KontoResource(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

    }
}
