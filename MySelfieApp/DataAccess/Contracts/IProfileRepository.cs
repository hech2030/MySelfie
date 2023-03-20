using MySelfieApp.Context.Models;

namespace MySelfieApp.DataAccess.Contracts
{
    public interface IProfileRepository
    {
        IAsyncEnumerable<Profile> GetAsync();
    }
}
