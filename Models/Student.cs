
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(20)]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid Email address")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Class is required")]
        [StringLength(50)]
        public string Class { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
