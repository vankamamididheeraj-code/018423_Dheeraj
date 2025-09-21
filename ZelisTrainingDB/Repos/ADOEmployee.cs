using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingDB.Models;
using Microsoft.Data.SqlClient;

namespace ZelisTrainingDB.Repos
{
    public class ADOEmployee : IEmployee
    {
        SqlConnection con;
        SqlCommand cmd;
         
        public ADOEmployee()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd =new SqlCommand();
            cmd.Connection = con;   
        }
        public void NewEmployee(Employee emp)
        {
            cmd.CommandText = $"insert into Employee values({emp.EmpId},'{emp.EmpName}','{emp.EmpDesignation}','{emp.EmpEmail}',{emp.EmpPhone})";
            con.Open(); 
            cmd.ExecuteNonQuery();
            con.Close() ;
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            cmd.CommandText = $"update Employee Set EmpName = '{employee.EmpName}', EmpDesignation = '{employee.EmpDesignation}', EmpEmail = '{employee.EmpEmail}', EmpPhone = {employee.EmpPhone} where EmpId = {employee.EmpId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteEmployee(int id)
        {

            cmd.CommandText = $"delete from Employee where EmpId ={id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();    
        }

        public List<Employee> GetAllEmployees()
        {
            cmd.CommandText = $"Select * from Employee";
            con.Open();
            List<Employee> employees = new List<Employee>();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("List of All Employees....");
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmpId = (int)(reader["EmpId"]);
                employee.EmpName = (string)(reader["EmpName"]);
                employee.EmpDesignation = (string)(reader["EmpDesignation"]);
                employee.EmpEmail = (string)(reader["EmpEmail"]);
                employee.EmpPhone = (string)(reader["EmpPhone"]);
                employees.Add(employee);
            }
            con.Close();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            cmd.CommandText=$"select * from Employee where EmpId={ id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                reader.Read();
                Employee employee = new Employee();
                employee.EmpId = (int)(reader["EmpId"]);
                employee.EmpName = (string)(reader["EmpName"]);
                employee.EmpDesignation = (string)(reader["EmpDesignation"]);
                employee.EmpEmail = (string)(reader["EmpEmail"]);
                employee.EmpPhone = (string)(reader["EmpPhone"]);
                con.Close();
                return employee;    
            }
            else
            {
                con.Close();
                throw new TrainingException("Employee Not Found"); 
            }
           
        }

        public List<Employee> GetEmployeeByDesignation(string designation)
        {
            cmd.CommandText=$"select * from Employee Where Designation='{designation}'";
            con.Open();
            List<Employee> employees = new List<Employee>();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("List of All Employees....");
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmpId = (int)(reader["EmpId"]);
                employee.EmpName = (string)(reader["EmpName"]);
                employee.EmpDesignation = (string)(reader["Designation"]);
                employee.EmpEmail = (string)(reader["Email"]);
                employee.EmpPhone = (string)(reader["Phone"]);
                employees.Add(employee);
            }
            con.Close();
            return employees;
        }

    }
}
