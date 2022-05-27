using entityCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
namespace entityCodeFirst.Data
{
    public class ClasseDbContext:DbContext
    {
        public ClasseDbContext(DbContextOptions<ClasseDbContext> options) : base(options)
        {

        }
        

        public DbSet<Classe> Classes { get; set; }
    }
}
