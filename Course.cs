using System.ComponentModel.DataAnnotations;

namespace CourseRegister.Model
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

            public string CourseName { get; set; } = string.Empty;
        public ICollection<Register> Registrations { get; set; }
            = new List<Register>();

    }
    }

