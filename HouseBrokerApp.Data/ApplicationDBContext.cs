using Microsoft.EntityFrameworkCore;

namespace HouseBrokerApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        // DbSet properties here
    }
}
