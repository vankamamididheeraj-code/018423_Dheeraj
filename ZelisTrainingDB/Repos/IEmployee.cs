using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingDB.Models;

namespace ZelisTrainingDB.Repos
{
    public interface IEmployee
    {
        void NewEmployee(Employee emp);
        void UpdateEmployee(int id,Employee employee);

        void DeleteEmployee(int id);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployeeByDesignation(string designation);

    }
}
