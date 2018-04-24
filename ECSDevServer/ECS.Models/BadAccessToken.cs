using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECS.Models
{
    public class BadAccessToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BadTokenId { get; set; }

        [Required]
        public string BadTokenValue { get; set; }

        public BadAccessToken()
        {
            BadTokenValue = "";
        }
        public BadAccessToken(string badTokenValue)
        {
            BadTokenValue = badTokenValue;
        }
    }
}
