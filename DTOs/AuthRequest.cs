using System.ComponentModel.DataAnnotations;

namespace ttcm_api.DTOs
{
    public class AuthRequest
    {

        [Required]
        [MinLength(4, ErrorMessage ="Too Short Username")]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Too Short Password")]
        public string Password { get; set; }
    }
}
