using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthentication.Persistance.Entities
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }     
        public byte[] PasswordSalt { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
