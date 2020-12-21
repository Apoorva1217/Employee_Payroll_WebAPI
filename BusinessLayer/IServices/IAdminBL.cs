using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.IServices
{
    public interface IAdminBL
    {
        EmployeeModel AdminLogin(AdminModel login);
        
        List<EmployeeModel> GetAllEmployee();
        
        bool RegisterAdmin(RegisterModel admin);
    }
}
