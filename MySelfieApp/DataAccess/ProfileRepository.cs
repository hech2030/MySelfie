using MySelfieApp.Context;
using MySelfieApp.Context.Models;
using MySelfieApp.DataAccess.Contracts;

namespace MySelfieApp.DataAccess
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProfileRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IAsyncEnumerable<Profile> GetAsync()
        {
            return this.applicationDbContext.Profiles.AsAsyncEnumerable();
        }
    }
}
