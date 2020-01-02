using System.ComponentModel.DataAnnotations;

namespace Acme.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Activity { get; set; }
        [MaxLength(250)]
        public string Comment { get; set; }
    }
}
