using CommonLayer.RequestModel;
using RepositoryLayer.ContextModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.IServices
{
    public interface IEmployeeBL
    {
        
        List<CompanyEmployee> GetAllEmployee();
        
        bool RegisterEmployee(RegisterModel employee);
    }
}
