using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApproxWeatherAPI.Entities.PropertySettings
{
    public class ProfileSettings
    {
        public static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.URL).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.Headers).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.Schema).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.DateCreated).IsRequired();
        }
    }
}