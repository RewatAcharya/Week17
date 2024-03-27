using System.ComponentModel.DataAnnotations;

namespace Week17
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
    }
}
