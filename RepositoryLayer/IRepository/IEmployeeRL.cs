using RepositoryLayer.ContextModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.IRepository
{
    public interface IEmployeeRL
    { 
        
        List<CompanyEmployee> GetAllEmployee();
    }
}
