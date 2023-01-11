using Modellayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslayer.Interface
{
    public interface IEmpRegBL
    {
        public EmployeeModel AddEmployee(EmployeeModel usermodel);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel UpdateEmployee(EmployeeModel employee);
        public string DeleteEmployee(int? id);
        public EmployeeModel GetEmployeeData(int? id);

    }
}
