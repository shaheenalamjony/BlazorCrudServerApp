using EmployeeManagement.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class DataExtraService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DataExtraService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        //Get All Employees
        public async Task<List<Designation>> GetAllDesignation()
        {
            try
            {
                var designationList = await _applicationDbContext.Designations.ToListAsync();
                return designationList;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while getting all Designations.", ex);
            }
        }
        public async Task<List<Department>> GetAllDepartment()
        {
            try
            {
                var departmentsList = await _applicationDbContext.Departments.ToListAsync();
                return departmentsList;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while getting all Departments.", ex);
            }
        }
        public async Task<List<Department>> DepartmentWiseDesignationList()
        {
            try
            {
                var departmentsWiseDesignationList = await _applicationDbContext
                    .Departments
                    .Include(d => d.Designations)
                    .ToListAsync();
                return departmentsWiseDesignationList;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new Exception("Error occurred while getting all Departments.", ex);
            }
        }



    }
}
