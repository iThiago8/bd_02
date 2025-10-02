using System.ComponentModel.DataAnnotations;

namespace Greenhouse.Models
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float SensorValue { get; set; }
        public DateTime SensorEvent { get; set; } = DateTime.Now;
    }
}
