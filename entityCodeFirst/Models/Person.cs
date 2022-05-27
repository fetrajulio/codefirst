namespace entityCodeFirst.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public string Pass { get; set; }

        public int IdClasse { get; set; }
        public int Connect { get; set; }

        public Person (int id, string name, int age, string email, string pass, int idClasse)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
            Pass = pass;
            IdClasse = idClasse;
           
        }
        public Person(string name, int age, string email, string pass, int idClasse)
        {
            Name = name;
            Age = age;
            Email = email;
            Pass = pass;
            IdClasse = idClasse;
        }
        public Person() { }
      
    }
}
