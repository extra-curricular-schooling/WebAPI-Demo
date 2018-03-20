using System.ComponentModel.DataAnnotations;

namespace ECS.Models
{
    public class ExpiredAccessToken
    {
        public ExpiredAccessToken()
        {

        }
        public ExpiredAccessToken(string token)
        {
            Token = token;
        }

        [Key]
        public string Token { get; set; }
    }
}
