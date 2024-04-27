using Microsoft.EntityFrameworkCore;

namespace proyectococina2.Models
{
    public class cocinadbContext : DbContext
    {
        public cocinadbContext(DbContextOptions<cocinadbContext> options) : base(options)
        {

        }
        public DbSet<Pedido> pedido { get; set; }
    }
}
