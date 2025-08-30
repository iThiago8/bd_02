using SilverstoneStates.Models;

namespace SilverstoneStates.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreatedAsync();

            if (context.Realties.Any())
                return;

            var realties = new Realty[]
            {
                new() { Id = 1, Name = "Casa de Campo", Description = "Uma bela casa com 3 quartos e vista para as montanhas.", NumberOfRooms = 3, Market_Value = 75000.00m },
                new() { Id = 2, Name = "Apartamento no Centro", Description = "Apartamento moderno de 2 quartos no coração da cidade.", NumberOfRooms = 2, Market_Value = 480000.50m },
                new() { Id = 3, Name = "Loft Moderno", Description = "Loft com design industrial, espaço aberto e pé-direito alto.", NumberOfRooms = 1, Market_Value = 920000.00m },
                new() { Id = 4, Name = "Sobrado Geminado", Description = "Sobrado com 4 quartos, ideal para famílias grandes.", NumberOfRooms = 4, Market_Value = 650000.00m },
                new() { Id = 5, Name = "Kitnet Estudantil", Description = "Espaço compacto e funcional, próximo à universidade.", NumberOfRooms = 1, Market_Value = 250000.00m },
                new() { Id = 6, Name = "Cobertura Duplex", Description = "Cobertura com piscina privativa e área gourmet.", NumberOfRooms = 3, Market_Value = 1800000.00m }
            };

            foreach (Realty r in realties)
            {
                context.Realties.Add(r);
            }
            context.SaveChanges();
        }
    }
}
