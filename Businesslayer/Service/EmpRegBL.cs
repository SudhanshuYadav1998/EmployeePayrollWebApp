using Businesslayer.Interface;
using Modellayer;
using Repositorylayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslayer.Service
{
    public class EmpRegBL:IEmpRegBL
    {
        private readonly IEmpRegRL empRegRL;
        public EmpRegBL(IEmpRegRL empRegRL)
        {
            this.empRegRL = empRegRL;
        }
        public EmployeeModel AddEmployee(EmployeeModel usermodel)
        {
            return this.empRegRL.AddEmployee(usermodel);
        }

        public string DeleteEmployee(int? id)
        {
            return empRegRL.DeleteEmployee(id);
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return this.empRegRL.GetAllEmployees();
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            return this.empRegRL.GetEmployeeData(id);
        }

        public EmployeeModel UpdateEmployee(EmployeeModel employee)
        {
            return empRegRL.UpdateEmployee(employee);
        }

    }
}
