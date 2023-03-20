using Microsoft.EntityFrameworkCore;
using MySelfieApp.Context.Config;
using MySelfieApp.Context.Models;
using System.Reflection;

namespace MySelfieApp.Context.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            return assembly.GetTypes().Where(x => !x.IsAbstract && x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
        }

        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var mappingTypes = assembly.GetMappingTypes(typeof(IEntityMappingConfiguration<>));
            foreach (var config in mappingTypes.Select(Activator.CreateInstance).Cast<IEntityMappingConfiguration>())
            {
                config.Map(modelBuilder);
            }
        }

        public static void AddApplicationUserConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.Address)
                .HasMaxLength(100);

                entity.Property(e => e.City)
                .HasMaxLength(100);

                entity.Property(e => e.BirthDate);

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getutcdate())");
            });
        }
    }
}
