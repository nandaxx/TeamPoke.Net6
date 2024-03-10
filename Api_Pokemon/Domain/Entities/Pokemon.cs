

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Pokemon 
    {

        public int Id { get; set; }
        [Key]
        public int IdIdentification { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }   
        public int Height { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public Pokemon() { }
    }
}
