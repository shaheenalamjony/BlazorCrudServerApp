using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(50, ErrorMessage = "Department name must not exceed 50 characters")]
        public string Name { get; set; }

        public List<Designation> Designations { get; set; }
    }
}