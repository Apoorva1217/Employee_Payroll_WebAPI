using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositoryLayer.ContextModel;
using RepositoryLayer.DBContextFiles;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Repository
{
    public class AdminRL : IAdminRL
    {
        private readonly EmployeeContext context;

        public AdminRL(EmployeeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Login Admin
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public EmployeeModel AdminLogin(AdminModel login)
        {
            try
            {
                return this.context.Employees.Where(x =>
                                                 x.Email == login.Email && x.Password == login.Password
                                                 && x.Role == "Admin")
                                    .Select(o => new EmployeeModel
                                    {
                                        EmployeeId = o.EmployeeId,
                                        Email = o.Email,
                                        FirstName = o.FirstName,
                                        LastName = o.LastName,
                                        PhoneNumber = o.PhoneNumber,
                                        CreatedDateTime = o.CreatedDateTime,
                                        Role = o.Role,
                                        ModifiedDateTime = o.ModifiedDateTime
                                    }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get All Employees from Employee Payroll DB
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return this.context.Employees.Where(x => x.Role == "Employee")
                    .Select(o => new EmployeeModel
                    {
                        EmployeeId = o.EmployeeId,
                        Email = o.Email,
                        FirstName = o.FirstName,
                        LastName = o.LastName,
                        PhoneNumber = o.PhoneNumber,
                        CreatedDateTime = o.CreatedDateTime,
                        Role = o.Role,
                        ModifiedDateTime = o.ModifiedDateTime
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Add Employee to the Employee Payroll DB
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool RegisterAdmin(RegisterModel admin)
        {
            try
            {
                CompanyEmployee adminObject = new CompanyEmployee()
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    Password = admin.Password,
                    PhoneNumber = admin.PhoneNumber,
                    Role = "Admin",
                    CreatedDateTime = DateTime.UtcNow,
                    ModifiedDateTime = null
                };

                this.context.Employees.Add(adminObject);
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
    }
}
