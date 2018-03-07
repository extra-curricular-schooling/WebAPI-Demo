using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECS.Models
{
    public class Token
    {
        [Required]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenId { get; set; }

        //foreign key
        [Key]
        [Column(Order = 0)]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5-20 characters")]
        public string Username { get; set; }

        [Required]
        [Column(Order = 2)]
        public string Value { get; set; }

        //navigation property of Token class
        public virtual User User { get; set; }
    }
}
