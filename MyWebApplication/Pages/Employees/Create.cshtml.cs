using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        IEmployee empRepo = new ADOEmployee();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            empRepo.NewEmployee(Employee);
            return RedirectToPage("/Employees/Index");
        }
    }
}
