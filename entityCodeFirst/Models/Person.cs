namespace entityCodeFirst.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public string Pass { get; set; }

        public Person (int id, string name, int age, string email, string pass)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
            Pass = pass;
        }
        public Person() { }
    }
}
