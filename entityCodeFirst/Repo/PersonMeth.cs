using entityCodeFirst.Data;
using entityCodeFirst.Models;
using System.Collections.Generic;
using System.Linq;

namespace entityCodeFirst.Repo
{
    public class PersonMeth
    {
        public readonly MyDbContext _context;
        public PersonMeth(MyDbContext context)
        {
            _context = context;
        }
        public void Connected(Person P)
        {
            
            Person p = _context.Persons.FirstOrDefault(x => x.Id == P.Id);
            p.Connect = 1;
            _context.SaveChanges();
        }
        public void Deconect(Person P)
        {
            Person p = _context.Persons.FirstOrDefault(x => x.Id == P.Id);
            p.Connect = 0;
            _context.SaveChanges();
        }
        public Person Auth(string email,string mdp)
        {
            Person p = _context.Persons.FirstOrDefault(x => x.Email==email && x.Pass==mdp);

            return p;
        }
        public void Ajout(Person p)
        {

            _context.Persons.Add(p);
            _context.SaveChanges();
        }

        public void change(int IdP)
        {
            Person p = _context.Persons.FirstOrDefault(x => x.Id == IdP) ;
            p.Pass = "niova";
            _context.SaveChanges();
        }

        public void change2()
        {
            List<Person> people=_context.Persons.ToList();
            foreach(Person p in people)
            {
                p.Age = 14;
            }
            _context.SaveChanges();
        } 

        public Person[] trier(Person[] t)
        {
            Person tmp;
            List<Person> people = new List<Person>();
            for(int i = 0; i < t.Length; i++)
            {
                for(int j=i+1;j<t.Length;j++)
                if (t[i].Age > t[j].Age)
                    {
                        tmp = t[i];
                        t[i] = t[j];
                        t[j] = tmp;
                    }
            }
            return t;
        }
    }
}
