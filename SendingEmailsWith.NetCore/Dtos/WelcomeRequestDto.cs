using System.ComponentModel.DataAnnotations;

namespace SendingEmailsWith.NetCore.Dtos
{
    public class WelcomeRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
