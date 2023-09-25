using Microsoft.EntityFrameworkCore;

namespace AddressManager.Domain.Models.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Endereco> endereco { get; set; }

    }
}
