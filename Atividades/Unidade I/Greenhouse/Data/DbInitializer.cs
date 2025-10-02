using Greenhouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenhouse.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (!context.Plants.Any())
            {
                var plants = new Plant[]
                {
                    new (){Name = "Sunflower", SensorValue = 4.23f},
                    new (){Name = "Lily", SensorValue = 2.53f},
                    new (){Name = "Grass", SensorValue = 1.48f},
                    new (){Name = "Tulip", SensorValue = 5.97f},
                };

                context.Plants.AddRange(plants);
                context.SaveChanges();
            }
        }
    }
}
