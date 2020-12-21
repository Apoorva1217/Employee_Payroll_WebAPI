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
