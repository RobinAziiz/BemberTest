using BemberTest.Models;

namespace BemberTest.Repositories
{
    public interface IAnstalldDapperRepository
    {
        Task<IEnumerable<Anstalld>> GetAllAsync();
        Task<Anstalld> GetByIdAsync(int id);
        Task<int> AddAsync(Anstalld anstalld);
        Task<bool> UpdateAsync(Anstalld anstalld);
        Task<bool> DeleteAsync(int id);
    }
}
