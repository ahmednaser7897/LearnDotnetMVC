using System.ComponentModel.DataAnnotations;

namespace MVCIdentityAuthentication.ViewModel;

public class RoleViewModel
{
    [Required]
    [Display(Name = "Role Name")]
    public required string RoleName { get; set; }
}
