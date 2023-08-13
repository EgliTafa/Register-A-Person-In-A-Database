using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Register_A_Person_In_A_Database_Backend_.Models;
using System.Threading.Tasks;

namespace Register_A_Person_In_A_Database_Backend_.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        // DbSet for the User table, which represents the application users
        public DbSet<People> Peoples { get; set; }
    }
}
