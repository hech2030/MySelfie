using Microsoft.EntityFrameworkCore;
using MySelfieApp.Context.Extensions;
using MySelfieApp.Context.Models;
using System;
using System.Reflection.Metadata;

namespace MySelfieApp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        protected ApplicationDbContext()
        {

        }

        public virtual DbSet<Profile> Profiles { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Guard.Against.Null(modelBuilder, nameof(modelBuilder));

            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
