using Microsoft.EntityFrameworkCore;
using ttcm_api.Models;

namespace ttcm_api.Contexts
{
    public class MainAppContext:DbContext
    {
        public DbSet<ttcm_api.Models.Program> Programs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public MainAppContext(DbContextOptions<MainAppContext> options):base(options)
        {

        }
    }
}
