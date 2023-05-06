using Microsoft.EntityFrameworkCore;
using Project.Domain.FormClass;

namespace Project.Web.Models
{
    public class TempContext:DbContext
    {
        public TempContext()
        {
        }
        public TempContext(DbContextOptions<TempContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("test");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Project.Domain.FormClass.Login>? Login { get; set; }
    }
}
