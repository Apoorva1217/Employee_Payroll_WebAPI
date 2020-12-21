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
    }
}
