using System.ComponentModel.DataAnnotations;

namespace SilverstoneStates.Models
{
    public class Realty
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal Market_Value { get; set; }

    }
}
