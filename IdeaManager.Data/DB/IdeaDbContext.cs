using IdeaManager.Core.Entities;
using IdeaManager.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IdeaManager.Data.Db
{
    public class IdeaDbContext : DbContext
    {
        public IdeaDbContext(DbContextOptions<IdeaDbContext> options) : base(options) { }

        //tables
        public DbSet<Idea> Ideas => Set<Idea>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Vote> Votes => Set<Vote>();

        //conf entite
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IdeaConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());
        }
    }
}

