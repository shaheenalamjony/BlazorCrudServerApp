using EmployeeManagement.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        #region Update

        //Try Catch Use korte hobe
        //Message er ta lagate hobe has errer, error message like previous project

        #endregion
        //Get All Employees
        public async Task<List<Employee>> GetAllEmployees()
        {
            var employeeList = _applicationDbContext.Employees.ToListAsync();
            return await employeeList;
        }
        //Insert Employee
        public async Task<bool> AddNewEmployee(Employee employee)
        {
            await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        //Get Employee By Id
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee? employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return null;
            }
            return employee;
        }
        //Update Employee
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Delete Employee
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

    }
}
