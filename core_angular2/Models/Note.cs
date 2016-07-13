using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_angular2.Models
{
    [Table("Notes")]
    public class Note
    {
        [Required, Key]
        public float Id { get; set; }

        [Display(Name = "ノート名"), MaxLength(50)]
        public string Name { get; set; }
    }
}
