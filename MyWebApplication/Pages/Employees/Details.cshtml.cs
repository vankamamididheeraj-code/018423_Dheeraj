using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        int empid;
        public Employee Employee { get; set; }
        IEmployee empRepo = new ADOEmployee();
        public void OnGet(int eid )
        {
            Employee =empRepo.GetEmployeeById(eid);
        }
        public IActionResult OnPost()
        {
            empRepo.DeleteEmployee(empid);
            return RedirectToPage("/Employees/Index");

        }
    }
}
