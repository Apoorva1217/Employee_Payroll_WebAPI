using CommonLayer.RequestModel;
using RepositoryLayer.ContextModel;
using RepositoryLayer.DBContextFiles;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Repository
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly EmployeeContext context;

        public EmployeeRL(EmployeeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Add Employee to the Employee Payroll DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool RegisterEmployee(RegisterModel employee)
        {
            try
            {
                CompanyEmployee employeeObject = new CompanyEmployee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Password = employee.Password,
                    PhoneNumber = employee.PhoneNumber,
                    Role = "Employee",
                    CreatedDateTime = DateTime.UtcNow,
                    ModifiedDateTime = null
                };

                this.context.Employees.Add(employeeObject);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get All Employee from Employee Payroll DB
        /// </summary>
        /// <returns></returns>
        public List<CompanyEmployee> GetAllEmployee()
        {
            try
            {
                List<CompanyEmployee> list = (from e in this.context.Employees
                                              select new CompanyEmployee
                                              {
                                                  EmployeeId = e.EmployeeId,
                                                  FirstName = e.FirstName,
                                                  LastName = e.LastName,
                                                  PhoneNumber = e.PhoneNumber,
                                                  Email = e.Email,
                                                  Role = e.Role,
                                                  CreatedDateTime = e.CreatedDateTime,
                                                  ModifiedDateTime = e.ModifiedDateTime
                                              }).ToList<CompanyEmployee>();

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
