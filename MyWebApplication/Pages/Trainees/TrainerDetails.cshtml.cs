using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace MyWebApplication.Pages.Trainees
{
    public class TrainerDetailsModel : PageModel
    {
        public Employee Employee { get; set; }
        IEmployee empRepo = new ADOEmployee();
        public void OnGet(int eid)
        {
            Employee = empRepo.GetEmployeeById(eid);
        }
    }
}