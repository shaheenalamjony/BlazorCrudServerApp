using EmployeeManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
       


        
        public async Task<List<Employee>> GetPagedEmployees(string searchEmail = "", int? pageSize = null, int? pageNo = null)
        {
            IQueryable<Employee> query = _applicationDbContext.Employees.OrderBy(x => x.Id);

            if (!string.IsNullOrEmpty(searchEmail))
            {
                query = query.Where(q => q.EmailAddress.ToLower().Contains(searchEmail.ToLower()));
            }

            if (pageNo.HasValue && pageSize.HasValue && pageNo.Value >= 0 && pageSize.Value > 0)
            {
                pageNo = pageNo.Value > 1 ? pageNo.Value - 1 : 0;

                query = query.Skip(pageNo.Value * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync();
        }

        // Get Total Employees Count
        public async Task<int> GetTotalEmployeesCount(string searchEmail)
        {
            IQueryable<Employee> query = _applicationDbContext.Employees;

            if (!string.IsNullOrEmpty(searchEmail))
            {
                query = query.Where(e => e.EmailAddress.Contains(searchEmail));
            }

            return await query.CountAsync();
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
