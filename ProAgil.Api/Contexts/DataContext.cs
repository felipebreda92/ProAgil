using Microsoft.EntityFrameworkCore;
using ProAgil.Api.Models;

namespace ProAgil.Api.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Evento> Evento { get; set; }
    }
}