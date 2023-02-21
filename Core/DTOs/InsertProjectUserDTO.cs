using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class InsertProjectUserDTO
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Does'nt match with Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string RoleName { get; set; }
    }

}
