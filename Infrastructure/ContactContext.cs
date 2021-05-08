using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class ContactContext : DbContext
    {
        public ContactContext()
        { }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {

                var param = Expression.Parameter(entityType.ClrType);
                var propMethodInformation = typeof(EF).GetMethod("Property")?.MakeGenericMethod(typeof(bool));
                var deletedProp = Expression.Call(propMethodInformation, param, Expression.Constant("Deleted"));
                var compareExpression = Expression.MakeBinary(ExpressionType.Equal, deletedProp, Expression.Constant(false));
                var lambda = Expression.Lambda(compareExpression, param);
                builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

            builder.Entity<User>()
                        .Property(e => e.Id)
                        .ValueGeneratedOnAdd();

            builder.Entity<User>().HasData(
                 new User() { Id = Guid.NewGuid().ToString() });


            #region User

            builder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Name = "Serhat KAYA",
                Username = "s.kaya@kayaserhat.com",
                Password = "candie007".GetMD5(),
                Deleted = false,
                CreatedUser = Guid.NewGuid().ToString()
            });

            #endregion
        }

        public class ContactContextContextFactory : IDesignTimeDbContextFactory<ContactContext>
        {
            public ContactContext CreateDbContext(string[] args)
            {
                var path = Directory.GetCurrentDirectory();
                path = path.Replace("Infrastructure", "API");
                var configuration = new ConfigurationBuilder().AddJsonFile($"{path}\\appsettings.json").Build();
                var optionsBuilder = new DbContextOptionsBuilder<ContactContext>();
                optionsBuilder.UseSqlServer(configuration.GetSection("AppConfiguration:ConnectionString").Value);
                return new ContactContext(optionsBuilder.Options);
            }
        }
    }
}
