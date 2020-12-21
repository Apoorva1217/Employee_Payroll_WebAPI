using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.IRepository
{
    public interface IAdminRL
    {
        EmployeeModel AdminLogin(AdminModel login);
        
        List<EmployeeModel> GetAllEmployee();

        bool RegisterAdmin(RegisterModel admin);
    }
}
