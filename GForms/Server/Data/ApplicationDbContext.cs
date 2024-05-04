using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GForms.Shared;
using Microsoft.AspNetCore.Identity;

namespace GForms.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .Property(b => b.ConcurrencyStamp)
                .HasColumnType("TEXT");

            builder.Entity<ApplicationUser>()
                .Navigation(e => e.Tests).AutoInclude();
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerVariant> AnswerVariants { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
