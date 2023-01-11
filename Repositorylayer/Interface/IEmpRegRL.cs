using Modellayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorylayer.Interface
{
    public interface IEmpRegRL
    {
        EmployeeModel AddEmployee(EmployeeModel usermodel);
        IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel UpdateEmployee(EmployeeModel employee);
        public string DeleteEmployee(int? id);
        public EmployeeModel GetEmployeeData(int? id);
    }
}
