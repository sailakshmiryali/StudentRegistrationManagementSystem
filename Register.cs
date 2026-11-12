using System.ComponentModel.DataAnnotations;

namespace CourseRegister.Model
{
    public class Register
    {
        public int RegisterId { get; set; }
        [Required]
        public string name { get; set; } =string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        [Required]
        public string mobile { get; set; } = string.Empty;
        [Required]
        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
