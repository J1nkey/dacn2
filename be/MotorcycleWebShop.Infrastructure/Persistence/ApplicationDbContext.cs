using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Common;
using MotorcycleWebShop.Domain.Entities;
using MotorcycleWebShop.Domain.Interfaces;

namespace MotorcycleWebShop.Infrastructure.Persistence
{
    public class ApplicationDbContext : 
        IdentityDbContext<ApplicationUser, ApplicationRole, int>,
        IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            :base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<NavigationBarItem> NavigationBarItems { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<MotorcycleType> MotorcycleTypes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreateBy = _currentUserService.UserId;
                        entry.Entity.CreatedAt = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModifiedAt = _dateTime.Now; 
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //builder.ApplyConfiguration<ApplicationUser>(new ApplicationUserConfiguration());
            //builder.ApplyConfiguration<ApplicationRole>(new ApplicationRoleConfiguration());

            // Configuration for Identity system
            builder.Entity<IdentityUserRole<int>>(options =>
            {
                options.ToTable("UserRoles");
                options.HasKey(x => new { x.UserId, x.RoleId });
            });

            builder.Entity<IdentityRoleClaim<int>>(options =>
            {
                options.ToTable("RoleClaims");
                options.HasKey(x => x.Id);
            });
                

            builder.Entity<IdentityUserClaim<int>>(options =>
            {
                options.ToTable("UserClaims");
                options.HasKey(x => x.Id);
            });


            builder.Entity<IdentityUserLogin<int>>(options =>
            {
                options.ToTable("UserLogins");
                options.HasKey(x => x.UserId);
            });

            builder.Entity<IdentityUserToken<int>>(options =>
            {
                options.ToTable("UserTokens");
                options.HasKey(x => x.UserId);
            });
        }
    }
}
