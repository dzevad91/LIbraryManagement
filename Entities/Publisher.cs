using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}