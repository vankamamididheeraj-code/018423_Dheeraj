using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using Microsoft.Data.SqlClient;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public required Employee Employee { get; set; }
        IEmployee empRepo = new ADOEmployee();
        static int empid;
        public void OnGet(int eid)
        {
            empid = eid;
            Employee= empRepo.GetEmployeeById(empid);   
        }
        public IActionResult OnPost()
        {
            empRepo.UpdateEmployee(empid, Employee);
            return RedirectToPage("/Employees/Index");

        }
    }
}
