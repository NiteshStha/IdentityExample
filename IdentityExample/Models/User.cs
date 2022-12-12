using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityExample.Models
{
    public class User : IdentityUser
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
