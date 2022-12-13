using System.ComponentModel.DataAnnotations;

namespace IdentityExample.ViewModels.Admin
{
    public class CreateRoleViewModel
    {
        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Role Name is required.")]
        public string RoleName { get; set; } = string.Empty;
    }
}
