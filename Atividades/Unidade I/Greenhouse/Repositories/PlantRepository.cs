using Greenhouse.Data;
using Greenhouse.Interfaces;
using Greenhouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenhouse.Repositories
{
    public class PlantRepository(ApplicationDbContext context) : IPlantRepository
    {
        public async Task Create(Plant plant)
        {
            await context.Plants.AddAsync(plant);
            await context.SaveChangesAsync();
        }
        public async Task Update(Plant plant)
        {
            context.Plants.Update(plant);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Plant plant)
        {
            context.Plants.Remove(plant);
            await context.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            return await context.Plants.CountAsync();
        }

        public async Task<List<Plant>?> GetAll()
        {
            return await context.Plants.ToListAsync();
        }

        public async Task<Plant?> GetById(int id)
        {
            return await context.Plants.FindAsync(id) ?? null;
        }

        public async Task<List<Plant>?> GetByName(string name)
        {
            return await
                context.Plants
                .Where(p => p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                .ToListAsync();

        }
    }
}
