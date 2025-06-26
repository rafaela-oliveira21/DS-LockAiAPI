using Microsoft.EntityFrameworkCore;
using LockAiAPI.Models;

namespace LockAiAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<PlanoLocacao> PlanoLocacao { get; set; }
    }
}
