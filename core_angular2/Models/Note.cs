using System.ComponentModel.DataAnnotations;

namespace core_angular2.Models
{
    public class Note
    {
        [Required, Key]
        public float Id { get; set; }

        [Display(Name = "ノート名"), MaxLength(50)]
        public string Name { get; set; }
    }
}
