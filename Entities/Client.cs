using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}