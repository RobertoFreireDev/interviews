using System.ComponentModel.DataAnnotations;

namespace userRegistrationPortal.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Insert a name")]
        [MinLength(3, ErrorMessage = "Name must has at least 3 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insert a gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Insert a gender")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Insert a email")]
        [EmailAddress(ErrorMessage = "Insert a valid email")]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }
    }
}
