using System.Data.Entity;
using SportTracker.Domain.Entities;

namespace SportTracker.Domain
{
   public class ModelContext : DbContext
   {
      public ModelContext()
         : base("SportTracker")
      {
         this.Configuration.LazyLoadingEnabled = false;
         this.Configuration.AutoDetectChangesEnabled = false;
      }   

      public DbSet<Muscle> Muscles { get; set; }
      public DbSet<Excercise> Excercises { get; set; }
      public DbSet<ProgramExcercise> ProgramExcercises { get; set; }
      public DbSet<Statistic> Statistics { get; set; }
      public DbSet<Training> Trainings { get; set; }
      public DbSet<BodyStamp> BodyStamps { get; set; }
      public DbSet<Tweet> Tweets { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Program> Programs { get; set; }
      public DbSet<Membership> Memberships { get; set; }
      public DbSet<OAuthMembership> OAuthMemberships { get; set; }
      public DbSet<Config> Configs { get; set; }
      public DbSet<Role> Roles { get; set; }
   }
}