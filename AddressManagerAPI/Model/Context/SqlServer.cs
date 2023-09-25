using Microsoft.EntityFrameworkCore;

namespace AddressManagerAPI.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Endereco> endereco { get; set; }

    }
}
