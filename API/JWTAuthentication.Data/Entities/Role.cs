using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthentication.Persistance.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        [InverseProperty(nameof(Permission.Role))]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
