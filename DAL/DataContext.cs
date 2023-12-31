using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.Extensions.Options;

namespace DAL
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Chair> Chairs { get; set; }
    }
}