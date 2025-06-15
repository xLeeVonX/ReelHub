using Microsoft.EntityFrameworkCore;
using ReelHub.Website.Models.Database;

namespace ReelHub.Website.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<Director> Directors { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(ma => ma.MovieId);
            
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.Movies)
                .HasForeignKey(ma => ma.ActorId);
            
            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Movie)
                .WithMany(m => m.Directors)
                .HasForeignKey(md => md.MovieId);

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(md => md.DirectorId);
        }
    }
}
