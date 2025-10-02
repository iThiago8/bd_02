using Greenhouse.Models;

namespace Greenhouse.Interfaces
{
    public interface IPlantRepository
    {
        public Task Create(Plant plant);
        public Task Update(Plant plant);
        public Task Delete(Plant plant);
        public Task<int> Count();
        public Task<Plant?> GetById(int id);
        public Task<List<Plant>?> GetByName(string name);
        public Task<List<Plant>?> GetAll();
    }
}
