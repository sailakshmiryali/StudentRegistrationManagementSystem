using System.ComponentModel.DataAnnotations;

namespace CourseRegister.DTO
{
    
        public class RegistrationRequest
        {
            [Required]
            public string StudentName { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [Phone]
            public string Phone { get; set; } = string.Empty;

            [Required]
            [Range(1, int.MaxValue)]
            public int CourseId { get; set; }
        }
    }

