using EncurtaAI.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EncurtaAI.API.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<Link> Links { get; set; }
}
