using EmployeeManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        //Get All Employees
        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                var employeeList = await _applicationDbContext.Employees.ToListAsync();
                return employeeList;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while getting all employees.", ex);
            }
        }

        //Get Paged Employees
        public async Task<List<Employee>> GetPagedEmployees(string searchEmail = "", int? pageSize = null, int? pageNo = null)
        {
            try
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

                var result = await query.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while getting paged employees.", ex);
            }
        }

        // Get Total Employees Count
        public async Task<int> GetTotalEmployeesCount(string searchEmail)
        {
            try
            {
                IQueryable<Employee> query = _applicationDbContext.Employees;

                if (!string.IsNullOrEmpty(searchEmail))
                {
                    query = query.Where(e => e.EmailAddress.Contains(searchEmail));
                }

                var count = await query.CountAsync();
                return count;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while getting total employees count.", ex);
            }
        }

        //Insert Employee
        public async Task<bool> AddNewEmployee(Employee employee)
        {
            try
            {
                await _applicationDbContext.Employees.AddAsync(employee);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while adding new employee.", ex);
            }
        }

        //Get Employee By Id
        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                Employee? employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

                return employee;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while getting employee by ID.", ex);
            }
        }

        //Update Employee
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                _applicationDbContext.Employees.Update(employee);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while updating employee.", ex);
            }
        }

        //Delete Employee
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            try
            {
                _applicationDbContext.Employees.Remove(employee);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while deleting employee.", ex);
            }
        }
    }
}
