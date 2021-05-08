using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Persistance.Entities
{
    public class UserLoginDetails
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
