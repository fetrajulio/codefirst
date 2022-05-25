using entityCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace entityCodeFirst.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options) : base(options)
        {

        }
        public MyDbContext() { }

        public DbSet<Person> Persons { get; set; }
    }
}
