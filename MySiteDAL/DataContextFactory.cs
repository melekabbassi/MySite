using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MySiteDAL
{
    internal class DataContextFactory : IDesignTimeDbContextFactory<MySiteContext>
    {
        public MySiteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MySiteContext>();
            optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DBIRM21;Integrated Security=true");

            return new MySiteContext(optionsBuilder.Options);
        }
    }
}
