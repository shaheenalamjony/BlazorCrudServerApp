using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Region { get; set; }
    }
}
