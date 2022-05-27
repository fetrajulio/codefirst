using entityCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace entityCodeFirst.Data
{
    public class AmieDbContext:DbContext
    {
        public AmieDbContext(DbContextOptions<AmieDbContext> options) : base(options)
        {

        }


        public DbSet<Amie> Amis { get; set; }
    }
}
