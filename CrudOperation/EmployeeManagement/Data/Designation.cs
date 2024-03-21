using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Designation title is required")]
        [StringLength(50, ErrorMessage = "Designation title must not exceed 50 characters")]
        public string Title { get; set; }
        [ForeignKey("DepartmentId")]
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}