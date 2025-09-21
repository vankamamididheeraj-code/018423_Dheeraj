using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using Microsoft.Data.SqlClient;
namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public List<Employee> emp = new List<Employee>();
        IEmployee empRepo = new ADOEmployee();
        public void OnGet()
        {
            emp = empRepo.GetAllEmployees();
        }
    }
}
