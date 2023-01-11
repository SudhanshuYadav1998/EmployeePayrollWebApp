using Microsoft.Extensions.Configuration;
using Modellayer;
using Repositorylayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repositorylayer.Service
{
    public class EmpRegRL:IEmpRegRL
    {
        SqlConnection sqlConnection;
        private readonly IConfiguration configuration;
        public EmpRegRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();

            this.sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC"));
            using (sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();
                    employee.ProfileImage = rdr["ProfileImg"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);



                    lstemployee.Add(employee);
                }
                sqlConnection.Close();
            }
            return lstemployee;
        }
        public EmployeeModel AddEmployee(EmployeeModel usermodel)
        {
            this.sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC"));
            using (sqlConnection)
                try
                {

                    SqlCommand command = new SqlCommand("spAddEmployee", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    this.sqlConnection.Open();

                    command.Parameters.AddWithValue("@Name", usermodel.Name);
                    command.Parameters.AddWithValue("@Notes", usermodel.Notes);
                    command.Parameters.AddWithValue("@ProfileImg", usermodel.ProfileImage);
                    command.Parameters.AddWithValue("@Department", usermodel.Department);
                    command.Parameters.AddWithValue("@Salary", usermodel.Salary);
                    command.Parameters.AddWithValue("@Gender", usermodel.Gender);
                    command.Parameters.AddWithValue("@StartDate", usermodel.StartDate);

                    var result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return usermodel;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    this.sqlConnection.Close();
                }

        }
        //To Update the records of a particluar employee    
        public EmployeeModel UpdateEmployee(EmployeeModel employee)
        {
            this.sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC"));
            using (sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                cmd.Parameters.AddWithValue("@ProfileImg", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return employee;
            }
        }

        //Get the details of a particular employee    
        public EmployeeModel GetEmployeeData(int? id)
        {
            EmployeeModel employee = new EmployeeModel();

            this.sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC"));
            using (sqlConnection)
            {
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();
                    employee.ProfileImage = rdr["ProfileImg"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);


                }
            }
            return employee;
        }

        //To Delete the record on a particular employee    
        public string DeleteEmployee(int? id)
        {

            this.sqlConnection = new SqlConnection(this.configuration.GetConnectionString("EmployeePayrollMVC"));
            using (sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", id);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return "Employee is Deletd";
            }
        }
    }
}
