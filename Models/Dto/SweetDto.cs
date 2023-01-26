using Sweeter.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sweeter.Models.Dto
{
    public class SweetDto
    {

        [Required]
        [StringLength(255)]
        public string Text { get; set; }

    }
}
