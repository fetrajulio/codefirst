namespace entityCodeFirst.Models
{
    public class Amie
    {
        public int Id { get; set; }
        public int IdP1 { get; set; }
        public int IdP2 { get; set; }

        public Amie(int id, int idP1, int idP2)
        {
            Id = id;
            IdP1 = idP1;
            IdP2 = idP2;
        }
        public Amie() { }
    }
}
