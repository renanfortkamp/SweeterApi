using System.ComponentModel.DataAnnotations;

namespace Sweeter.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
