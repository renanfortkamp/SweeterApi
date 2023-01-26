using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sweeter.Models.Entities
{
    public class Sweet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        public DateTime DataPostagem { get; set; } = DateTime.Now;
        public int EnumStatus { get; set; } = 1;
        public bool Editado { get; set; } = false;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }



    }
}
