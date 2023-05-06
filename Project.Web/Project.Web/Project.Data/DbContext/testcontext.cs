using Microsoft.EntityFrameworkCore;
using Project.Common.Models;
using Project.Data.DapperConnection;
using Project.Domain.Models;

namespace Project.Data.Context
{
    public class testcontext : DbContext
    {
        public testcontext()
        {
        }
        public testcontext(DbContextOptions<testcontext> options) : base(options)
        {        }
        public DbSet<User> User { get; set; }
        public DbSet<Todo> Todo { get; set; }
        public DbSet<Error> Error { get; set; }
    }
}
