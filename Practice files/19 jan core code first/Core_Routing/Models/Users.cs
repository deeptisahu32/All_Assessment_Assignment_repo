using System.ComponentModel.DataAnnotations;
namespace Core_Routing.Models
{
    public class Users
    {
        [Required(ErrorMessage ="Name is required")]
        public string ? UserName {  get; set; }
        [Required(ErrorMessage ="Email Needed")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string? Email { get; set; }
    }
}
